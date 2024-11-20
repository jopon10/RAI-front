using System.Windows.Controls;
using System.Windows;

namespace RAI.Controls
{
    public partial class BtAcao : UserControl
    {
        public event RoutedEventHandler Click;

        public string Text { get; set; }
        public string Tip { get; set; }

        public BtAcao()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (Text != null)
                txtLabel.Text = Text;

            if (Tip != null)
                btAcao.ToolTip = Tip;
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

        private void btAcao_Click(object sender, RoutedEventArgs e)
        {
            if (Click != null)
            {
                Click("Ação", e);
            }
        }
    }
}