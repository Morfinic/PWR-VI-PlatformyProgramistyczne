using PWR_VI_PodPro.Core.API.Models;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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

            ThumbImg.Source = new BitmapImage(new Uri(deal.thumb));
            TitleTb.Text = deal.title;

            normalPriceTb.Text = "Normal price: " + deal.normalPrice + '$';
            salePriceTb.Text = "Sale: " + deal.salePrice + '$';
            savingsTb.Text = "Discount: " + deal.savings.Substring(0, deal.savings.IndexOf('.')) + '%';

            MetacriticScoreTb.Text = deal.metacriticScore;
            MetacriticLink.Click += (s, e) =>Process.Start(new ProcessStartInfo("https://www.metacritic.com" + deal.metacriticLink) { UseShellExecute = true });

            SteamRatingTextTb.Text = deal.steamRatingText;
            SteamRatingPercentTb.Text = deal.steamRatingPercent;

            SteamLink.Click += (s, e) => Process.Start(new ProcessStartInfo("https://store.steampowered.com/app/" + deal.steamAppID) { UseShellExecute = true });
        }
    }
}
