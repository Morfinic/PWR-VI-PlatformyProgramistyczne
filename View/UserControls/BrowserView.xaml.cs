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
        private ObservableCollection<Deal> _deals = new();
        public ObservableCollection<Deal> Deals
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
            var ll = await DealController.GetDeals();

            foreach (DealModel obj in ll)
            {
                Deal newDeal = new(obj, false);
                _deals.Add(newDeal);
            }
        }

        private void UserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _deals.Clear();
        }

        private async void SearchBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var SearchName = SearchBox.SearchInput.Text;
            _deals.Clear();

            string onSale = (bool)ShowOnlyOnSaleChkbx.IsChecked ? "1" : "0";
            var ll = await DealController.GetDeals(SearchName, onSale);

            foreach (DealModel obj in ll)
            {
                Deal newDeal = new(obj, false);
                _deals.Add(newDeal);
            }

            SearchBox.SearchInput.Text = "";
        }
    }
}
