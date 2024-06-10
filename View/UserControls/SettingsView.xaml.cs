using PWR_VI_PodPro.Core.MongoDB.DB;
using PWR_VI_PodPro.Core;
using PWR_VI_PodPro.View.Components;
using System.Windows;
using System.Windows.Controls;
using PWR_VI_PodPro.View.ViewComponents;
using PWR_VI_PodPro.Core.API.Calls;

namespace PWR_VI_PodPro.View.UserControls
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Funkcja obsługująca przycisk zmiany maila
        /// </summary>
        private void UpdateEmail_Click(object sender, RoutedEventArgs e)
        {
            EmailInputWindow inputWindow = new("Update email:")
            {
                Owner = Application.Current.MainWindow
            };
            Application.Current.MainWindow.Effect = new System.Windows.Media.Effects.BlurEffect();
            inputWindow.ShowDialog();
            Application.Current.MainWindow.Effect = null;

            if (inputWindow.Success)
            {
                LoggedUser.Email = inputWindow.Email;
                DB.UpdateUser();
                MessageTb.Text = "Email updated!";
            }
        }

        /// <summary>
        /// Funkcja obsługująca pytanie o wysłanie maila do zarządzania alertami
        /// </summary>
        private async void ManAlertbtn_Click(object sender, RoutedEventArgs e)
        {
            string res = await AlertController.SendManageEmail();
            MessageTb.Text = res;
        }
    }
}
