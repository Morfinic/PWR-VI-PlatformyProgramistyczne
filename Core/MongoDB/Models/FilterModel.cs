using MongoDB.Bson;

namespace PWR_VI_PodPro.Core.MongoDB.Models
{
    /// <summary>
    /// Klasa modelu filtru do bazy danych
    /// </summary>
    public class FilterModel
    {
        public BsonObjectId _id { get; set; }
        public string filterName { get; set; }
        public string deviceId { get; set; }
        public string lowerPrice { get; set; }
        public string upperPrice { get; set; }
        public string title { get; set; }
        public string AAA { get; set; }
        public string metacritic { get; set; }
    }
}
