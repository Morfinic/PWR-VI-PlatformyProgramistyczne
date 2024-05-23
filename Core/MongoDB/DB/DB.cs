using MongoDB.Driver;
using PWR_VI_PodPro.Core.MongoDB.Models;
using PWR_VI_PodPro.View.Components;
using System.IO;
using System.Windows;

namespace PWR_VI_PodPro.Core.MongoDB.DB
{
    public class DB
    {
        public static string CnnString { get; set; }
        public static IMongoDatabase DbName { get; set; }
        public static IMongoCollection<UsersModel> UsersColl { get; set; }

        public static void InitializeConn()
        {
            CnnString = System.Configuration.ConfigurationManager.ConnectionStrings["MongoDbUrl"].ConnectionString;

            var settings = MongoClientSettings.FromConnectionString(CnnString);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            var client = new MongoClient(settings);
            DbName = client.GetDatabase("GameSales");
            UsersColl = DbName.GetCollection<UsersModel>("Users");
        }

        public static bool checkLoggedUser()
        {
            var user = UsersColl.Find(x => x.DeviceId == LoggedUser.DeviceId).FirstOrDefault();
            if(user == null)
                return true;
            return false;
        }

        public static void AddUser()
        {
            UsersColl.InsertOne(new UsersModel
            {
                DeviceId = LoggedUser.DeviceId,
                email = LoggedUser.Email
            });
        }

        public static void LoadUser()
        {
            var user = UsersColl.Find(x => x.DeviceId == LoggedUser.DeviceId).FirstOrDefault();
            if (user != null)
            {
                LoggedUser.Email = user.email;
            }
        }

        public static void UpdateUser()
        {
            var filter = Builders<UsersModel>.Filter.Eq("DeviceId", LoggedUser.DeviceId);
            var update = Builders<UsersModel>.Update.Set("email", LoggedUser.Email);
            UsersColl.UpdateOne(filter, update);
        }
    }
}
