using PWR_VI_PodPro.Core.API.Calls;
using PWR_VI_PodPro.Core.API.Models;
using PWR_VI_PodPro.View.Components;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace PWR_VI_PodPro.View.UserControls
{
    /// <summary>
    /// Interaction logic for BrowserView.xaml
    /// </summary>
    public partial class BrowserView : UserControl
    {
        private ObservableCollection<TextBox> _deals = new();
        public ObservableCollection<TextBox> Deals
        {
            get { return _deals; }
            set { _deals = value; }
        }

        public BrowserView()
        {
            DataContext = this;
            InitializeComponent();
        }

        private async void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var ll = await DealController.Get3A();

            foreach (DealModel obj in ll)
            {
                TextBox tb = new()
                {
                    Text = $"Title: {obj.title}, " +
                           $"Price: {obj.normalPrice}, " +
                           $"DiscountedTo: {obj.salePrice}, " +
                           $"Savings%: {obj.savings}, " +
                           $"SteamRating%: {obj.steamRatingPercent}, " +
                           $"SteamRate: {obj.steamRatingText}"
                };

                new Deal(obj);

                _deals.Add(tb);
            }
        }

        private void UserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _deals.Clear();
        }
    }
}
