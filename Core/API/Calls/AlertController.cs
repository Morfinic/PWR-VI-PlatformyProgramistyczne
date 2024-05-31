﻿using PWR_VI_PodPro.Core.API.Models;
using System.Net.Http;

namespace PWR_VI_PodPro.Core.API.Calls
{
    class AlertController
    {
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
    }
}
