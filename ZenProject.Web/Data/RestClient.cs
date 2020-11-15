using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ZenProject.Web.Data
{
    public partial class RestClient
    {
        public async Task<T> PutRequest<T>(string url)
        {
            return await SendRequest<T>(url, HttpMethod.Put);
        }

        public async Task<T> PostRequest<T>(string url)
        {
            return await SendRequest<T>(url, HttpMethod.Post);
        }

        public async Task<T> DeleteRequest<T>(string url)
        {
            return await SendRequest<T>(url, HttpMethod.Delete);
        }

        public async Task<T> GetRequest<T>(string url)
        {
            return await SendRequest<T>(url, HttpMethod.Get);
        }

        private async Task<T> SendRequest<T>(string url, HttpMethod method)
        {
            var httpClient = new HttpClient();

            var requestUrl = new Uri(url);


            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = method,
                RequestUri = requestUrl
            };

            var response = await httpClient.SendAsync(request);
            var responseMessage = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);

            return responseMessage;
        }
    }
}
