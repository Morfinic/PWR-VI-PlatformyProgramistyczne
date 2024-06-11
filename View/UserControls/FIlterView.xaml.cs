using MongoDB.Bson;
using PWR_VI_PodPro.Core.API.Calls;
using PWR_VI_PodPro.Core.API.Models;
using PWR_VI_PodPro.Core.MongoDB.DB;
using PWR_VI_PodPro.Core.MongoDB.Models;
using PWR_VI_PodPro.View.Components;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace PWR_VI_PodPro.View.UserControls
{
    /// <summary>
    /// Interaction logic for FIlterView.xaml
    /// </summary>
    public partial class FilterView : UserControl
    {
        private ObservableCollection<Deal> _deals = new();
        public ObservableCollection<Deal> Deals
        {
            get { return _deals; }
            set { _deals = value; }
        }

        private ObservableCollection<FilterModel> _filterData = new();
        public ObservableCollection<FilterModel> FilterData
        {
            get { return _filterData; }
            set { _filterData = value; }
        }

        public FilterView()
        {
            DataContext = this;
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            FilterWindow inputWindow = new()
            {
                Owner = Application.Current.MainWindow
            };

            this.Effect = new System.Windows.Media.Effects.BlurEffect();
            inputWindow.ShowDialog();
            this.Effect = null;

            FilterData.Add(DB.GetRecentFilter());
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var ll = DB.GetUserFilter();
            foreach (FilterModel obj in ll)
            {
                FilterData.Add(obj);
            }
        }

        private void UserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            FilterData.Clear();
            Deals.Clear();
        }

        private async void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var idx = FilterBox.SelectedIndex;
            if (idx == -1)
                return;
            var filter = FilterData[idx];

            if(filter != null)
            {
                _deals.Clear();
                var ll = await DealController.GetDealByQuery(filter);

                foreach (DealModel obj in ll)
                {
                    Deal newDeal = new(obj, false);
                    _deals.Add(newDeal);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var idx = FilterBox.SelectedIndex;
            if (idx == -1)
                return;
            var filter = FilterData[idx];

            if (filter != null)
            {
                DB.RemoveFilter(filter._id);
                FilterData.Remove(filter);
            }

            FilterBox.SelectedIndex = -1;
        }
    }
}
