using PWR_VI_PodPro.Core;
using PWR_VI_PodPro.Core.API.Calls;
using System.Windows.Controls;
using System.Windows.Media;

namespace PWR_VI_PodPro.View.ViewComponents
{
    /// <summary>
    /// Interaction logic for InfoBar.xaml
    /// </summary>
    public partial class InfoBar : UserControl
    {
        public InfoBar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Funkcja ustawiająca kolory kropek w zależności od statusu API i sklepu
        /// </summary>
        private async void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if(ApiController.ApiClient == null)
            {
                ApiClientStatusDot.Fill = Brushes.Red;
            }
            else
            {
                ApiClientStatusDot.Fill = Brushes.Green;
            }

            var storeCall = await StoreController.LoadStoreStatus();

            if (storeCall.isActive)
            {
                SteamStatusDot.Fill = Brushes.Green;
            }
            else
            {
                SteamStatusDot.Fill = Brushes.Red;
            }
        }
    }
}
