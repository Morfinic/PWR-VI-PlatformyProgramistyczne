using PWR_VI_PodPro.Core.MongoDB.Models;
using PWR_VI_PodPro.View.Components;
using System.Collections.ObjectModel;
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

        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void UserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
