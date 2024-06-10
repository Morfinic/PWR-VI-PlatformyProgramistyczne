using PWR_VI_PodPro.Core.API.Models;
using System.Net.Http;

namespace PWR_VI_PodPro.Core.API.Calls
{
    /// <summary>
    /// Klasa odpowiedzialna za wywoływanie zapytań związanych z alertami.
    /// </summary>
    class AlertController
    {
        /// <summary>
        /// Funkcja odpowiedzialna za wysłanie zapytania o wysłanie na mail zalogowanego użytkownika linku do zarządzania alertami.
        /// </summary>
        /// <returns>
        ///     Odpowiedź o poprawności wykonania zapytania.
        ///     True - zapytanie wykonane poprawnie.
        ///     False - Użytkownik nie posiada aktywnych alertów lub niedawno wysłał już zapytanie.
        /// </returns>
        public static async Task<string> SendManageEmail()
        {
            string url = $"https://www.cheapshark.com/api/1.0/alerts?action=manage&email={LoggedUser.Email}";

            using (HttpResponseMessage res = await ApiController.ApiClient.GetAsync(url))
            {
                if (res.IsSuccessStatusCode)
                {
                    return res.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    return res.Content.ReadAsStringAsync().Result;
                }
            }
        }

        /// <summary>
        /// Funkcja odpowiedzialna za wysłanie zapytania o dodanie nowego alertu.
        /// </summary>
        /// <param name="gameID">Id produktu</param>
        /// <param name="price">Poniżej jakij ceny ma zostć wysłane powiadomienie mailowe</param>
        /// <returns>
        ///     True - zapytanie wykonane poprawnie.
        ///     False - zapytanie nie zostało wykonane poprawnie.
        /// </returns>
        public static async Task<bool> EditAlert(string gameID, string price)
        {
            string url = $"https://www.cheapshark.com/api/1.0/alerts?action=set&email={LoggedUser.Email}&gameID={gameID}&price={price}";

            using (HttpResponseMessage res = await ApiController.ApiClient.GetAsync(url))
            {
                if (res.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
