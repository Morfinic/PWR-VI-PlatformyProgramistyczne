using MongoDB.Bson;

namespace PWR_VI_PodPro.Core.MongoDB.Models
{
    /// <summary>
    /// Klasa modelu użytkownika
    /// </summary>
    public class UsersModel
    {
        public BsonObjectId _id { get; set; }
        public string DeviceId { get; set; }
        public string email { get; set; }
    }
}
