using Telerik.Windows.Persistence;
using MaterialDesignThemes.Wpf;
using Telerik.Windows.Controls;
using System.Windows.Data;
using System.Windows;
using System.Linq;
using System.IO;
using RAI.API;
using System;

namespace RAI.Controls
{
    public class GridViewContextMenu
    {
        private Stream stream { get; set; }

        private readonly RadGridView grid = null;
        private readonly string folderLayout = $"{AppDomain.CurrentDomain.BaseDirectory}Layout\\";

        public GridViewContextMenu(RadGridView grid)
        {
            this.grid = grid;
        }

        public static readonly DependencyProperty IsEnabledProperty
            = DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(GridViewContextMenu),
                new PropertyMetadata(new PropertyChangedCallback(OnIsEnabledPropertyChanged)));

        public static void SetIsEnabled(DependencyObject dependencyObject, bool enabled)
        {
            dependencyObject.SetValue(IsEnabledProperty, enabled);
        }

        public static bool GetIsEnabled(DependencyObject dependencyObject)
        {
            return (bool)dependencyObject.GetValue(IsEnabledProperty);
        }

        private static void OnIsEnabledPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var grid = dependencyObject as RadGridView;
            if (grid != null)
            {
                if ((bool)e.NewValue)
                {
                    var menu = new GridViewContextMenu(grid);
                    menu.Attach();
                }
            }
        }

        private void Attach()
        {
            if (grid != null)
            {
                var contextMenu = new RadContextMenu();
                StyleManager.SetTheme(contextMenu, StyleManager.GetTheme(grid));

                contextMenu.Opened += OnMenuOpened;

                RadContextMenu.SetContextMenu(grid, contextMenu);
            }
        }

        void OnMenuOpened(object sender, RoutedEventArgs e)
        {
            var menu = (RadContextMenu)sender;
            menu.Items.Clear();

            var item = new RadMenuItem();
            item.Header = "Limpar Filtros";
            item.Icon = new PackIcon { Kind = PackIconKind.FilterOffOutline, Width = 24, Height = 24 };
            item.Click += LimparFiltros;
            menu.Items.Add(item);

            item = new RadMenuItem();
            item.Header = "Seletor de Colunas";
            item.Icon = new PackIcon { Kind = PackIconKind.ViewColumnOutline, Width = 24, Height = 24 };
            menu.Items.Add(item);

            foreach (GridViewColumn column in grid.Columns)
            {
                if (column.Header != null && column.Header is string && column.Header.ToString().Trim().Length > 0)
                {
                    if (column.Tag != null && column.Tag is string && column.Tag.ToString() == "naoAparecer") continue;

                    var header = column.Header.ToString();
                    if (column.Tag != null && column.Tag is string) header = column.Tag.ToString();

                    var subMenu = new RadMenuItem();
                    subMenu.Header = header;
                    subMenu.IsCheckable = true;
                    subMenu.IsChecked = true;

                    var isCheckedBinding = new Binding("IsVisible");
                    isCheckedBinding.Mode = BindingMode.TwoWay;
                    isCheckedBinding.Source = column;

                    subMenu.SetBinding(RadMenuItem.IsCheckedProperty, isCheckedBinding);

                    item.Items.Add(subMenu);
                }
            }

            item = new RadMenuItem();
            item.Header = "Salvar Layout";
            item.Icon = new PackIcon { Kind = PackIconKind.ContentSaveOutline, Width = 24, Height = 24 };
            item.Click += SalvarLayout;
            menu.Items.Add(item);

            item = new RadMenuItem();
            item.Header = "Carregar Layout";
            item.Icon = new PackIcon { Kind = PackIconKind.Autorenew, Width = 24, Height = 24 };
            item.Click += CarregarLayout;
            menu.Items.Add(item);

            //if (Helper.Demo)
            //{
            //    item = new RadMenuItem();
            //    item.Header = "Restaurar Padrão Layout";
            //    item.Icon = new PackIcon { Kind = PackIconKind.ContentSaveOutline, Width = 24, Height = 24 };
            //    item.Click += PadraoLayout;
            //    menu.Items.Add(item);
            //}

            item = new RadMenuItem();
            item.Header = "Exportar para Excel";
            item.Icon = new PackIcon { Kind = PackIconKind.MicrosoftExcel, Width = 24, Height = 24 };
            item.Click += ExportarExcel;
            menu.Items.Add(item);
        }

        private string GetFileLayout()
        {
            var file = "";

            var pai = grid.GetParents().FirstOrDefault(f => f.GetType().Namespace.Contains("P_ON.Pages"));
            if (pai != null)
            {
                file = pai.GetType().FullName;
                file += ".layout";
            }

            return file;
        }

        private void SalvarLayout(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            try
            {
                var manager = new PersistenceManager();
                stream = manager.Save(grid);

                if (!Directory.Exists(folderLayout)) Directory.CreateDirectory(folderLayout);

                string file = GetFileLayout();
                if (file.Trim().Length == 0) return;

                string path = $"{folderLayout}{file}";
                using (var outputFileStream = new FileStream(path, FileMode.Create))
                {
                    stream.CopyTo(outputFileStream);
                }
            }
            catch (Exception ex)
            {
                Helper.ShowPonDialog(ex.Message, tipoMensagem: MessageBoxImage.Exclamation);
            }
        }

        private void CarregarLayout(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            try
            {
                if (!Directory.Exists(folderLayout)) return;

                string file = GetFileLayout();
                if (file.Trim().Length == 0) return;

                string path = $"{folderLayout}{file}";
                if (!File.Exists(path)) return;

                var fs = File.OpenRead(path);
                //fs.Seek(0, SeekOrigin.Begin); // <-- missing line
                //byte[] buf = new byte[fs.Length];
                //fs.Read(buf, 0, buf.Length);

                var manager = new PersistenceManager();
                fs.Position = 0L;
                manager.Load(grid, fs);

                fs.Close();
                fs.Dispose();
            }
            catch (Exception ex)
            {
                Helper.ShowPonDialog(ex.Message, tipoMensagem: MessageBoxImage.Exclamation);
            }
        }

        //private void PadraoLayout(object sender, Telerik.Windows.RadRoutedEventArgs e)
        //{
        //    var manager = new PersistenceManager();
        //    stream = null;
        //}

        private void LimparFiltros(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            grid.FilterDescriptors.Clear();
        }

        private void ExportarExcel(object sender, RoutedEventArgs e)
        {
            string extension = "xlsx";
            var dialog = new Microsoft.Win32.SaveFileDialog()
            {
                DefaultExt = extension,
                Filter = String.Format("{1} files (.{0})|.{0}|All files (.)|.", extension, "Excel"),
                FilterIndex = 1
            };

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    using (var stream = dialog.OpenFile())
                    {
                        grid.ExportToXlsx(stream);
                    }
                }
                catch (Exception ex)
                {
                    Helper.ShowPonDialog(ex.Message, tipoMensagem: MessageBoxImage.Exclamation);
                }
            }
        }
    }
}