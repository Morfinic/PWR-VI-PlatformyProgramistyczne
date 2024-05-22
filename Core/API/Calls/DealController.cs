using Newtonsoft.Json;
using PWR_VI_PodPro.Core.API.Models;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;

namespace PWR_VI_PodPro.Core.API.Calls
{
    class DealController
    {
        public static async Task<List<DealModel>> Get3A()
        {
            string url = "https://www.cheapshark.com/api/1.0/deals?storeID=1&AAA=1";

            using (HttpResponseMessage res = await ApiController.ApiClient.GetAsync(url))
            {
                if(res.IsSuccessStatusCode)
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
    }
}
