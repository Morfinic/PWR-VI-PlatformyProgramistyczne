using PWR_VI_PodPro.Core;
using PWR_VI_PodPro.Core.MongoDB.DB;
using PWR_VI_PodPro.View.Components;
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
            DB.InitializeConn();
            LoggedUser.InitUser();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (DB.checkLoggedUser())
            {
                EmailInputWindow inputWindow = new("First launch detected, need e-mail to proceed:")
                {
                    Owner = this
                };
                this.Effect = new System.Windows.Media.Effects.BlurEffect();
                inputWindow.ShowDialog();
                this.Effect = null;

                if (inputWindow.Success)
                {
                    LoggedUser.Email = inputWindow.Email;
                    DB.AddUser();
                }
            }
            else
            {
                DB.LoadUser();
            }
        }
    }
}