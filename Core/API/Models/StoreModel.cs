namespace PWR_VI_PodPro.Core.API.Models
{
    class StoreModel
    {
        public string storeID { get; set; }
        public string storeName{ get; set; }
        public bool isActive { get; set; }
        public Dictionary<string, string> images { get; set; }
    }
}
