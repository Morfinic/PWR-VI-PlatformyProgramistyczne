using PWR_VI_PodPro.Core.API.Calls;
using PWR_VI_PodPro.Core.API.Models;
using PWR_VI_PodPro.View.Components;
using System.Windows.Controls;

namespace PWR_VI_PodPro.View.UserControls
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private async void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var ll = await DealController.Get3A();

            foreach (DealModel obj in ll)
            {
                Deal newDeal = new(obj, false);
                DailyDealsSP.Children.Add(newDeal);
            }
        }

        private void UserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            DailyDealsSP.Children.Clear();
        }
    }
}
