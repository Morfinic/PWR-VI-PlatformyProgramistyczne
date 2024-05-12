using System.Net.Http;

namespace PWR_VI_PodPro.Core
{
    class ApiController
    {
        public static HttpClient? ApiClient { get; set; } = null;

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
