using Newtonsoft.Json;
using PWR_VI_PodPro.Core.API.Models;
using System.Diagnostics;
using System.Net.Http;

namespace PWR_VI_PodPro.Core.API.Calls
{
    class DealController
    {
        public static async Task<List<DealModel>> Get3A()
        {
            string url = $"https://www.cheapshark.com/api/1.0/deals?storeID=1&AAA=1&onSale=1";

            using (HttpResponseMessage res = await ApiController.ApiClient.GetAsync(url))
            {
                if(res.IsSuccessStatusCode)
                {
                    var deals = await res.Content.ReadAsStringAsync();
                    List<DealModel> ret = JsonConvert.DeserializeObject<List<DealModel>>(deals);

                    return ret.OrderBy(x => Random.Shared.Next()).Take(3).ToList();
                }
                else
                {
                    throw new Exception(res.ReasonPhrase);
                }
            }
        }

        public static async Task<List<DealModel>> GetDeals(string SearchName = "")
        {
            string url = $"https://www.cheapshark.com/api/1.0/deals?storeID=1&title={SearchName}";

            using (HttpResponseMessage res = await ApiController.ApiClient.GetAsync(url))
            {
                if (res.IsSuccessStatusCode)
                {
                    var deals = await res.Content.ReadAsStringAsync();
                    List<DealModel> ret = JsonConvert.DeserializeObject<List<DealModel>>(deals);

                    return ret;
                }
                else
                {
                    throw new Exception(res.ReasonPhrase);
                }
            }
        }

        public static async Task<DealModel> GetDealBySteamAppId(string steamApp = "")
        {
            string url = $"https://www.cheapshark.com/api/1.0/deals?storeID=1&steamAppID={steamApp}";

            using (HttpResponseMessage res = await ApiController.ApiClient.GetAsync(url))
            {
                if (res.IsSuccessStatusCode)
                {
                    var deals = await res.Content.ReadAsStringAsync();
                    Trace.WriteLine(deals);

                    List<DealModel> ret = JsonConvert.DeserializeObject<List<DealModel>>(deals);

                    return ret[0];
                }
                else
                {
                    throw new Exception(res.ReasonPhrase);
                }
            }
        }
    }
}
