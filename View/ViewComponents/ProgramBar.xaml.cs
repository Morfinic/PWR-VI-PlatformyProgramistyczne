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

        /// <summary>
        /// Funkcja pozwalająca na przesuwanie okna za pomocą kliknięcia paska
        /// </summary>
        private void dragBar_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Window.GetWindow(this).DragMove();
        }

        /// <summary>
        /// Funkcja zamykająca aplikację po wciśnięciu przycisku zamknięcia
        /// </summary>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Funkcja minimalizująca aplikację po wciśnięciu przycisku minimalizacji
        /// </summary>
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
    }
}
