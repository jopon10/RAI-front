using System.Windows.Controls.Primitives;
using MaterialDesignThemes.Wpf;
using Telerik.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace RAI.Controls
{
    public class WindowBase : Window
    {
        public bool gravou { get; set; }

        public WindowBase()
        {
            WindowStyle = WindowStyle.ToolWindow;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ResizeMode = ResizeMode.CanResizeWithGrip;
            ShadowAssist.SetCacheMode(this, null);

            var scrollBarStyle = new Style() { TargetType = typeof(ScrollBar) };
            scrollBarStyle.Setters.Add(new Setter() { Property = StyleManager.ThemeProperty, Value = new FluentTheme() });
            scrollBarStyle.Setters.Add(new Setter() { Property = OpacityProperty, Value = 0.75 });
            this.Resources.Add(typeof(ScrollBar), scrollBarStyle);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.Key == Key.Escape)
            {
                Close();
                e.Handled = true;
            }
        }
    }
}