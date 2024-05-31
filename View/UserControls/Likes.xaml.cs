using PWR_VI_PodPro.Core.API.Calls;
using PWR_VI_PodPro.Core.MongoDB.DB;
using PWR_VI_PodPro.Core.MongoDB.Models;
using PWR_VI_PodPro.View.Components;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Controls;

namespace PWR_VI_PodPro.View.UserControls
{
    /// <summary>
    /// Interaction logic for Likes.xaml
    /// </summary>
    public partial class Likes : UserControl
    {
        private ObservableCollection<Deal> _likes = new();
        public ObservableCollection<Deal> LikesList
        {
            get { return _likes; }
            set { _likes = value; }
        }

        public Likes()
        {
            DataContext = this;
            InitializeComponent();
        }

        private async void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var ll = DB.GetLikes();

            foreach (LikesModel obj in ll)
            {
                var game = await DealController.GetDealBySteamAppId(obj.AppId);

                Deal newDeal = new(game, true);
                newDeal.FavBtn.Click += (s, e) =>
                {
                    DB.RemoveLike(obj.AppId);
                    _likes.Remove(newDeal);
                };
                _likes.Add(newDeal);
            }
        }

        private void UserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _likes.Clear();
        }
    }
}
