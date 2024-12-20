using Telerik.Windows.Controls.GridView;
using MaterialDesignThemes.Wpf;
using Telerik.Windows.Controls;
using System.Windows;

namespace RAI.Controls
{
    public class ButtonColumnShow : GridViewColumn
    {
        public event RoutedEventHandler CustomClick;
        public PackIconKind IconKind { get; set; } = PackIconKind.Search;
        public double IconWidth { get; set; } = 24;
        public double IconHeight { get; set; } = 24;

        public string CustomCommand { get; set; }

        public double IconOpacity { get; set; } = 0.7;

        public bool VisibleIcon { get; set; } = true;

        public double? ButtonSize { get; set; }

        public override FrameworkElement CreateCellElement(GridViewCell cell, object dataItem)
        {
            var toolTip = cell.Column.ToolTip == null ? "Detalhar" : cell.Column.ToolTip;

            RadButton button = cell.Content as RadButton;

            button = new RadButton();
            //button.Width = 36;
            //button.Height = 36;
            button.Click += Button_Click;

            var icon = new PackIcon();

            if (!string.IsNullOrEmpty(CustomCommand) && dataItem != null)
            {
                if (CustomCommand == "OpacityMapaLocal")
                {
                    var local = dataItem as ViewModel.Local;
                    if (local.mapeado)
                    {
                        IconOpacity = 1;
                        toolTip = "Mapeado";
                    }
                    else
                    {
                        IconOpacity = 0.3;
                        toolTip = "Mapear";
                    }
                }

                if (CustomCommand == "VisibleCalagem")
                {
                    var analise = dataItem as ViewModel.AnaliseSolo;
                    if (analise.profundidade == "0-20 cm")
                        VisibleIcon = true;
                    else
                        VisibleIcon = false;
                }

                if (CustomCommand == "VisibleGessagem")
                {
                    var analise = dataItem as ViewModel.AnaliseSolo;
                    if (analise.profundidade == "20-40 cm" && analise.al.GetValueOrDefault() > 0.3M && analise.ca.GetValueOrDefault() < 0.5M && analise.m > 20)
                        VisibleIcon = true;
                    else
                        VisibleIcon = false;
                }
            }
            else
            {
                button.MouseEnter += Button_MouseEnter;
                button.MouseLeave += Button_MouseLeave;
            }

            Style style = this.FindResource("MaterialDesignIconButton") as Style;
            button.Style = style;

            icon.Kind = IconKind;

            if (ButtonSize != null)
            {
                button.Width = ButtonSize.Value;
                button.Height = ButtonSize.Value;

                icon.Width = IconWidth;
                icon.Height = IconHeight;
            }

            button.Content = icon;

            button.HorizontalAlignment = HorizontalAlignment.Right;

            button.ToolTip = toolTip;

            button.CommandParameter = dataItem;

            button.Opacity = IconOpacity;

            button.Visibility = VisibleIcon ? Visibility.Visible : Visibility.Collapsed;

            return button;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as RadButton;
            CustomClick?.Invoke(button.DataContext, new RoutedEventArgs());
        }

        private void Button_MouseEnter(object sender, RoutedEventArgs e)
        {
            var button = sender as RadButton;
            button.Opacity = 1;
        }

        private void Button_MouseLeave(object sender, RoutedEventArgs e)
        {
            var button = sender as RadButton;
            button.Opacity = IconOpacity;
        }
    }
}