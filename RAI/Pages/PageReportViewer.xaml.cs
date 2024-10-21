using System.Windows.Input;
using Telerik.Reporting;
using System.Windows;

namespace RAI.Pages
{
    public partial class PageReportViewer : Window
    {
        public PageReportViewer(InstanceReportSource instance)
        {
            InitializeComponent();

            ReportViewer1.ReportSource = instance;
            ReportViewer1.RefreshReport();
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

        private void Window_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (e.Delta > 0)
                    ReportViewer1.ZoomPercent += 5;
                else
                    ReportViewer1.ZoomPercent -= 5;

                e.Handled = true;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
                ReportViewer1.CanMoveToPage(2);
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
                if (ReportViewer1.NavigateForwardEnabled == true)
                    ReportViewer1.NavigateForward();
            }
        }
    }
}