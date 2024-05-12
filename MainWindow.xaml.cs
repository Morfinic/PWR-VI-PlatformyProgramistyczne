using PWR_VI_PodPro.Core;
using System.Windows;

namespace PWR_VI_PodPro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ApiController.InitializeClient();
        }
    }
}