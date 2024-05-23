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

            DailyDealsSP.Children.Add(new TextBlock() { Text="asd" });
        }
    }
}
