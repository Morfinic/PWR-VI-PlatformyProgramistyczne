using Newtonsoft.Json;
using PWR_VI_PodPro.Core.API.Models;
using PWR_VI_PodPro.Core.MongoDB.Models;
using System.Diagnostics;
using System.Net.Http;

namespace PWR_VI_PodPro.Core.API.Calls
{
    /// <summary>
    /// Klasa odpowiedzialna za wywoływanie zapytań związanych z ofertami.
    /// </summary>
    class DealController
    {
        /// <summary>
        /// Funkcja odpowiedzialna za pobranie 3 ofert z gier kategorii AAA.
        /// </summary>
        /// <returns>Trzy gry z kategori AAA</returns>
        /// <exception cref="Exception">
        ///     Wyjątek w przypadku niepowodzenia pobrania ofert.
        /// </exception>
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

        /// <summary>
        /// Funkcja odpowiedzialna za pobranie ofert gier.
        /// </summary>
        /// <param name="SearchName">
        ///     Opconalny parametr, nazwa gry do wyszukania.
        /// </param>
        /// <param name="onSale">
        ///     Opconalny parametr, określający czy gra jest w promocji.
        /// </param>
        /// <returns>
        ///     Listę ofert gier zapisanych w modelu DealModel.
        /// </returns>
        /// <exception cref="Exception">
        ///     Wyjątek w przypadku niepowodzenia pobrania ofert.
        /// </exception>
        public static async Task<List<DealModel>> GetDeals(string SearchName = "", string onSale = "1")
        {
            string url = $"https://www.cheapshark.com/api/1.0/deals?storeID=1&title={SearchName}&onSale={onSale}";

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

        /// <summary>
        /// Funkcja odpowiedzialna za pobranie oferty gry na podstawie jej SteamAppID.
        /// </summary>
        /// <param name="steamApp">
        ///     Parametr określający SteamAppID gry.
        /// </param>
        /// <returns>
        ///     Obiekt DealModel z danymi oferty.
        /// </returns>
        /// <exception cref="Exception">
        ///     Wyjątek w przypadku niepowodzenia pobrania oferty.
        /// </exception>
        public static async Task<DealModel> GetDealBySteamAppId(string steamApp = "")
        {
            string url = $"https://www.cheapshark.com/api/1.0/deals?storeID=1&steamAppID={steamApp}";

            using (HttpResponseMessage res = await ApiController.ApiClient.GetAsync(url))
            {
                if (res.IsSuccessStatusCode)
                {
                    var deals = await res.Content.ReadAsStringAsync();

                    List<DealModel> ret = JsonConvert.DeserializeObject<List<DealModel>>(deals);

                    return ret[0];
                }
                else
                {
                    throw new Exception(res.ReasonPhrase);
                }
            }
        }

        public static async Task<List<DealModel>> GetDealByQuery(FilterModel filter)
        {
            Trace.WriteLine(filter.title);

            string url = "https://www.cheapshark.com/api/1.0/deals?storeID=1" +
                $"&title={filter.title}" +
                $"&AAA={filter.AAA}";

            if (!string.IsNullOrWhiteSpace(filter.lowerPrice))
                url += $"&lowerPrice={filter.lowerPrice}";
            if (!string.IsNullOrWhiteSpace(filter.upperPrice))
                url += $"&upperPrice={filter.upperPrice}";
            if (!string.IsNullOrWhiteSpace(filter.metacritic))
                url += $"&metacritic={filter.metacritic}";

            Trace.WriteLine(url);

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
    }
}
