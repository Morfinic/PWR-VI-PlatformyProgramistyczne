using System.Windows;
using System.Windows.Controls;

namespace PWR_VI_PodPro.View.ViewComponents
{
    public partial class ProgramBar : UserControl
    {
        public ProgramBar()
        {
            InitializeComponent();
        }

        private void dragBar_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Window.GetWindow(this).DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
    }
}
