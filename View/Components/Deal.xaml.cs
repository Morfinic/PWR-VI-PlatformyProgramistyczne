using PWR_VI_PodPro.Core.API.Models;
using System.Windows.Controls;

namespace PWR_VI_PodPro.View.Components
{
    /// <summary>
    /// Interaction logic for Deal.xaml
    /// </summary>
    public partial class Deal : UserControl
    {
        public Deal(DealModel deal)
        {
            DataContext = this;
            InitializeComponent();

            Title.Text = deal.title;
        }
    }
}
