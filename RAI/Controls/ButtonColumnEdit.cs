using Telerik.Windows.Controls.GridView;
using MaterialDesignThemes.Wpf;
using Telerik.Windows.Controls;
using System.Windows;

namespace RAI.Controls
{
    public class ButtonColumnEdit : GridViewColumn
    {
        public event RoutedEventHandler CustomClick;

        public double? ButtonSize { get; set; }

        public override FrameworkElement CreateCellElement(GridViewCell cell, object dataItem)
        {
            var toolTip = cell.Column.ToolTip == null ? "Editar" : cell.Column.ToolTip;

            RadButton button = new RadButton();

            var icon = new PackIcon { Kind = PackIconKind.Edit };

            if (ButtonSize != null)
            {
                button.Width = ButtonSize.Value;
                button.Height = ButtonSize.Value;

                icon.Width = 18;
                icon.Height = 18;
            }

            button.Content = icon;

            button.Click += Button_Click;
            button.MouseEnter += Button_MouseEnter;
            button.MouseLeave += Button_MouseLeave;

            Style style = this.FindResource("MaterialDesignIconButton") as Style;
            button.Style = style;

            button.HorizontalAlignment = HorizontalAlignment.Right;
            button.ToolTip = toolTip;
            button.CommandParameter = dataItem;
            button.Opacity = 0.7;

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
            button.Opacity = 0.7;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as RadButton;
            CustomClick?.Invoke(button.DataContext, new RoutedEventArgs());
        }
    }
}