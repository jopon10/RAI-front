using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace RAI.Controls
{
    public partial class BtGravar : UserControl
    {
        public event RoutedEventHandler Click;

        public string Text { get; set; }
        public string Tip { get; set; }

        public BtGravar()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (Text != null)
                btGravar.Content = Text;

            if (Tip != null)
                btGravar.ToolTip = Tip;

            var window = Window.GetWindow(this);
            if (window != null)
                window.KeyDown += HandleKeyPress;
        }

        public void IsLoading(bool on)
        {
            if (on)
            {
                pb.Visibility = Visibility.Visible;
                this.IsEnabled = false;
            }
            else
            {
                pb.Visibility = Visibility.Collapsed;
                this.IsEnabled = true;
            }
        }

        private void btGravar_Click(object sender, RoutedEventArgs e)
        {
            if (Click != null)
            {
                Click("Gravar", e);
            }
        }

        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5 && this.IsEnabled && this.Visibility == Visibility.Visible)
            {
                if (Click != null)
                {
                    Click("Gravar", e);
                }
            }
        }
    }
}