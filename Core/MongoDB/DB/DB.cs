﻿using MongoDB.Driver;
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
        public static IMongoCollection<LikesModel> LikesColl { get; set; }

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
