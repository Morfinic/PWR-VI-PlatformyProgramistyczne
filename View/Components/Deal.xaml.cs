using PWR_VI_PodPro.Core.API.Models;
using PWR_VI_PodPro.Core.MongoDB.DB;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PWR_VI_PodPro.View.Components
{
    /// <summary>
    /// Interaction logic for Deal.xaml
    /// </summary>
    public partial class Deal : UserControl
    {
        public Deal(DealModel deal, bool fromLikes)
        {
            DataContext = this;
            InitializeComponent();

            ThumbImg.Source = new BitmapImage(new Uri(deal.thumb));
            TitleTb.Text = deal.title;

            normalPriceTb.Text = "Normal price: " + deal.normalPrice + '$';
            salePriceTb.Text = "Sale: " + deal.salePrice + '$';
            savingsTb.Text = "Discount: " + deal.savings.Substring(0, deal.savings.IndexOf('.')) + '%';

            MetacriticScoreTb.Text = deal.metacriticScore;
            MetacriticLink.Click += (s, e) => Process.Start(new ProcessStartInfo("https://www.metacritic.com" + deal.metacriticLink) { UseShellExecute = true });

            int metacriticScore = int.Parse(deal.metacriticScore);
            switch (metacriticScore)
            {
                case <= 0:
                    MetacriticBg.Background = Brushes.Black;
                    break;
                case > 0 and <= 25:
                    MetacriticBg.Background = Brushes.Red;
                    break;
                case > 25 and <= 50:
                    MetacriticBg.Background = Brushes.Orange;
                    break;
                case > 50 and <= 75:
                    MetacriticBg.Background = Brushes.YellowGreen;
                    break;
                case > 75:
                    MetacriticBg.Background = Brushes.Green;
                    break;
            }

            SteamRatingTextTb.Text = deal.steamRatingText;
            SteamRatingPercentTb.Text = deal.steamRatingPercent;

            SteamLink.Click += (s, e) => Process.Start(new ProcessStartInfo("https://store.steampowered.com/app/" + deal.steamAppID) { UseShellExecute = true });

            if (!fromLikes)
            {
                TextBlock popupText = new()
                {
                    Text = "Added to watchlist!",
                    Foreground = Brushes.White,
                    Background = Brushes.BlueViolet,
                    Padding = new Thickness(5),
                    FontSize = 20,
                };
                Popup popup = new()
                {
                    Child = popupText,
                    Placement = PlacementMode.Mouse,
                };

                FavBtn.Click += (s, e) =>
                {
                    DB.AddLike(deal.steamAppID);
                    popup.IsOpen = true;

                    Task.Delay(2000).ContinueWith(_ =>
                    {
                        Dispatcher.Invoke(() => popup.IsOpen = false);
                    });
                };

                FavBtn.Content = "Add";
            }
            else
            {
                FavBtn.Content = "Remove";
            }
        }
    }
}
