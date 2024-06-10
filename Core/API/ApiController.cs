using System.Net.Http;

namespace PWR_VI_PodPro.Core
{
    class ApiController
    {
        public static HttpClient? ApiClient { get; set; } = null;

        /// <summary>
        /// Funkcja inicjalizująca klienta API
        /// </summary>
        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
