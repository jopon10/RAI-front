using Telerik.Windows.Controls.MaterialControls;
using System.Collections.ObjectModel;
using RAI.Pages.Cadastros.Usuarios;
using RAI.Pages.Cadastros.Fazendas;
using RAI.Pages.Cadastros.Locais;
using System.Collections.Generic;
using MaterialDesignThemes.Wpf;
using System.Windows.Threading;
using Telerik.Windows.Controls;
using System.Windows.Controls;
using System.Windows.Input;
using System.Diagnostics;
using System.Windows;
using System.Linq;
using RAI.API;
using System;

namespace RAI.Pages
{
    public partial class PageMenu : Window
    {
        private List<NavigationViewItemModel> itemsMenu { get; set; }
        private DispatcherTimer timerToken { get; set; }

        //private string pathConfigTema = AppDomain.CurrentDomain.BaseDirectory + "//configTema.json";

        public PageMenu()
        {
            InitializeComponent();

            ThemeEffectsHelper.IsAcrylicEnabled = false;

            ShowAlertToken();

            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;

            lbFantasia.Text = Helper.user.Cliente;
            lbUser.Text = Helper.user.nome;
            lbVersao.Text = "Versão: " + Helper.Versao;

            this.DataContext = new NavigationViewItemModel();

            MontarMenu();

            //if (Helper.user.cor_primaria != null)
            //{
            //    Uri uri = new Uri($"pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.{Helper.user.cor_primaria}.xaml");

            //    Application.Current.Resources.MergedDictionaries.RemoveAt(12);
            //    Application.Current.Resources.MergedDictionaries.Insert(12, new ResourceDictionary() { Source = uri });

            //    uri = new Uri($"pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.{Helper.user.cor_secundaria}.xaml");

            //    Application.Current.Resources.MergedDictionaries.RemoveAt(13);
            //    Application.Current.Resources.MergedDictionaries.Insert(13, new ResourceDictionary() { Source = uri });

            //    var config = new ConfigTema { cor_primaria = Helper.user.cor_primaria, cor_secundaria = Helper.user.cor_secundaria };
            //    File.WriteAllText(pathConfigTema, JsonConvert.SerializeObject(config));
            //}
        }

        public void ShowAlertToken()
        {
            if (Debugger.IsAttached) return;

            timerToken = new DispatcherTimer();
            timerToken.Interval = TimeSpan.FromSeconds(36000);
            timerToken.Tick += TimerToken_Tick;
            
            timerToken.Start();
        }

        private void TimerToken_Tick(object sender, EventArgs e)
        {
            Helper.ShowPonDialog("Você esta logado a mais de 10 horas, por favor faça o login novamente! ", tipoMensagem: MessageBoxImage.Warning);
            Button_Click(null, null);
        }

        private void MontarMenu()
        {
            itemsMenu = new List<NavigationViewItemModel>();

            //var home = new NavigationViewItemModel() { Icon = PackIconKind.Home, Title = "Início", IsEnabled = true, FontWeight = FontWeights.Bold, page = new PageClimaPrevisao() };
            //if (home != null && !itemsMenu.Select(s => s.Title).Contains(home.Title))
            //    itemsMenu.Add(home);

            var cadastros = new NavigationViewItemModel() { Icon = PackIconKind.Register, Title = "Cadastros", FontWeight = FontWeights.Bold, IsEnabled = true };
            cadastros.SubItems = new ObservableCollection<NavigationViewItemModel>
            {
                //new NavigationViewItemModel() { Title = "Proprietários" , IsEnabled = Helper.user.proprietarios, page = new PageProprietarios() },
                new NavigationViewItemModel() { Title = "Fazendas", IsEnabled = Helper.user.fazendas, page = new PageFazendas() },
                new NavigationViewItemModel() { Title = "Talhões" , IsEnabled = Helper.user.locais, page = new PageLocais() },
                new NavigationViewItemModel() { Title = "Usuários", IsEnabled = Helper.user.usuarios, page = new PageUsuarios() },
            };
            if (cadastros != null && !itemsMenu.Select(s => s.Title).Contains(cadastros.Title))
                itemsMenu.Add(cadastros);

            NavigationView.ItemsSource = itemsMenu;
            NavigationView.SelectedIndex = 0;
        }

        private void ColorZone_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
        }

        private void ColorZone_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Minimizar(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await LoginAPI.LogoutAsync();
            Application.Current.Shutdown();
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender == null) return;

            var obj = (sender as UserControl).DataContext as NavigationViewItemModel;

            if (obj == null) return;

            if (obj.page == null || obj.semPage)
            {
                obj.page = (e.OldValue as NavigationViewItemModel).page;
                obj.semPage = true;
            }
        }

        private void pageTransitionControl_TriggeringTransition(object sender, Telerik.Windows.Controls.TransitionControl.TriggeringTransitionEventArgs e)
        {
            if (sender == null) return;

            var obj = (sender as RadTransitionControl).Content as NavigationViewItemModel;

            if (obj == null) return;

            if (obj.page == null || obj.semPage) e.Cancel = true;
        }

        private void itemDefinirTema_Click(object sender, RoutedEventArgs e)
        {
            //var window = new PageTema();
            //window.ShowDialog();
        }

        public class NavigationViewItemModel
        {
            public PackIconKind? Icon { get; set; }
            public string Title { get; set; }

            public bool IsEnabled { get; set; }
            public int NotificationsCount { get; set; }

            public FontWeight FontWeight { get; set; }

            public ObservableCollection<NavigationViewItemModel> SubItems { get; set; }

            public bool semPage { get; set; }

            public UserControl page { get; set; }
        }
    }
}