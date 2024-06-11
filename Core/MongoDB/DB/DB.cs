using MongoDB.Driver;
using PWR_VI_PodPro.Core.MongoDB.Models;
using PWR_VI_PodPro.View.Components;
using System.IO;
using System.Windows;

namespace PWR_VI_PodPro.Core.MongoDB.DB
{
    /// <summary>
    /// Logika połączenia z bazą danych MongoDB
    /// </summary>
    public class DB
    {
        public static string CnnString { get; set; }
        public static IMongoDatabase DbName { get; set; }
        public static IMongoCollection<UsersModel> UsersColl { get; set; }
        public static IMongoCollection<LikesModel> LikesColl { get; set; }
        public static IMongoCollection<FilterModel> FilterColl { get; set; }

        /// <summary>
        /// Funkcja inicjalizująca połączenie z bazą danych MongoDB oraz pobierająca kolekcje
        /// </summary>
        public static void InitializeConn()
        {
            CnnString = System.Configuration.ConfigurationManager.ConnectionStrings["MongoDbUrl"].ConnectionString;

            var settings = MongoClientSettings.FromConnectionString(CnnString);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            var client = new MongoClient(settings);
            DbName = client.GetDatabase("GameSales");
            UsersColl = DbName.GetCollection<UsersModel>("Users");
            LikesColl = DbName.GetCollection<LikesModel>("Likes");
        }

        /// <summary>
        /// Funkcja sprawdzająca czy użytkownik jest "zalogowany"
        /// </summary>
        /// <returns>
        ///     True - użytkownik nie jest zalogowany
        ///     False - użytkownik jest zalogowany
        /// </returns>
        public static bool checkLoggedUser()
        {
            var user = UsersColl.Find(x => x.DeviceId == LoggedUser.DeviceId).FirstOrDefault();
            if(user == null)
                return true;
            return false;
        }

        /// <summary>
        /// Funkcja dodająca użytkownika do bazy danych
        /// </summary>
        public static void AddUser()
        {
            UsersColl.InsertOne(new UsersModel
            {
                DeviceId = LoggedUser.DeviceId,
                email = LoggedUser.Email
            });
        }

        /// <summary>
        /// Funkcja wczytująca dane użytkownika z bazy danych i przypisujaca je do obiektu LoggedUser
        /// </summary>
        public static void LoadUser()
        {
            var user = UsersColl.Find(x => x.DeviceId == LoggedUser.DeviceId).FirstOrDefault();
            if (user != null)
            {
                LoggedUser.Email = user.email;
            }
        }

        /// <summary>
        /// Funkcja aktualizująca dane użytkownika w bazie danych
        /// </summary>
        public static void UpdateUser()
        {
            var filter = Builders<UsersModel>.Filter.Eq("DeviceId", LoggedUser.DeviceId);
            var update = Builders<UsersModel>.Update.Set("email", LoggedUser.Email);
            UsersColl.UpdateOne(filter, update);
        }

        /// <summary>
        /// Funkcja dodająca produkt do listy ulubionych dla aktualnie zalogowanego użytkownika
        /// </summary>
        /// <param name="appId">
        ///     Id produktu, który ma zostać dodany do listy ulubionych
        /// </param>
        public static void AddLike(string appId)
        {
            var app = LikesColl.Find(x => x.AppId == appId).FirstOrDefault();
            if (app != null)
                return;
            LikesColl.InsertOne(new LikesModel
            {
                DeviceId = LoggedUser.DeviceId,
                AppId = appId
            });
        }

        /// <summary>
        /// Funkcja usuwająca produkt z listy ulubionych dla aktualnie zalogowanego użytkownika
        /// </summary>
        /// <param name="appId">
        ///     Id produktu, który ma zostać usunięty z listy ulubionych
        /// </param>
        public static void RemoveLike(string appId)
        {
            LikesColl.DeleteOne(x => x.AppId == appId);
        }

        public static List<LikesModel> GetLikes()
        {
            var likes = LikesColl.Find(x => x.DeviceId == LoggedUser.DeviceId).ToList();
            return likes;
        }
    }
}
