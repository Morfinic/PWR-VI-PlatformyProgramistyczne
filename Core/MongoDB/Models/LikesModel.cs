using MongoDB.Bson;

namespace PWR_VI_PodPro.Core.MongoDB.Models
{
    public class LikesModel
    {
        public BsonObjectId _id { get; set; }
        public string DeviceId { get; set; }
        public string AppId { get; set; }
    }
}
