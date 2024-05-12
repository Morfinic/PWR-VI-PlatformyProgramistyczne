using Newtonsoft.Json;
using PWR_VI_PodPro.Core.API.Models;
using System.Net.Http;

namespace PWR_VI_PodPro.Core.API.Calls
{
    class StoreController
    {
        public static async Task<StoreModel> LoadStoreStatus()
        {
            string url = "https://www.cheapshark.com/api/1.0/stores";

            using (HttpResponseMessage res = await ApiController.ApiClient.GetAsync(url))
            {
                if (res.IsSuccessStatusCode)
                {
                    string responseBody = await res.Content.ReadAsStringAsync();
                    List<StoreModel> result = JsonConvert.DeserializeObject<List<StoreModel>>(responseBody);

                    return result[0];
                }
                else
                {
                    throw new Exception(res.ReasonPhrase);
                }
            }
        }
    }
}
