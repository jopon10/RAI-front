using Telerik.Windows.Controls.GridView;
using MaterialDesignThemes.Wpf;
using Telerik.Windows.Controls;
using System.Windows;
using RAI.API;

namespace RAI.Controls
{
    public class ButtonColumnDelete : GridViewColumn
    {
        public event RoutedEventHandler DeleteClick;

        public double? ButtonSize { get; set; }

        public override FrameworkElement CreateCellElement(GridViewCell cell, object dataItem)
        {
            var toolTip = cell.Column.ToolTip == null ? "Excluir" : cell.Column.ToolTip;

            RadButton button = cell.Content as RadButton;

            button = new RadButton();
            button.Click += Button_Click;
            button.MouseEnter += Button_MouseEnter;
            button.MouseLeave += Button_MouseLeave;
            button.Tag = cell.Column.Tag;

            Style style = this.FindResource("MaterialDesignIconButton") as Style;
            button.Style = style;

            var icon = new PackIcon { Kind = PackIconKind.Delete };

            if (ButtonSize != null)
            {
                button.Width = ButtonSize.Value;
                button.Height = ButtonSize.Value;

                icon.Width = 18;
                icon.Height = 18;
            }

            button.Content = icon;
            button.HorizontalAlignment = HorizontalAlignment.Right;
            button.ToolTip = toolTip;
            button.Opacity = 0.3;
            button.CommandParameter = dataItem;

            return button;
        }

        private void Button_MouseEnter(object sender, RoutedEventArgs e)
        {
            var button = sender as RadButton;
            button.Opacity = 1;
        }
        private void Button_MouseLeave(object sender, RoutedEventArgs e)
        {
            var button = sender as RadButton;
            button.Opacity = 0.3;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as RadButton;

            var msg = button.Tag ?? "Deseja excluir este registro?";

            var result = Helper.ShowPonDialog(msg.ToString(), simNao: true, tipoMensagem: MessageBoxImage.Question);
            if (!result) return;

            DeleteClick?.Invoke(button.DataContext, new RoutedEventArgs());
        }
    }
}