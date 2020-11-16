using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ZenProject.Web.Data
{
    public partial class RestClient
    {
        private readonly HttpClient _httpClient;
        private static RestClient _instance;

        #region Constructor

        public static RestClient Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new RestClient();
                return _instance;
            }
        }

        public RestClient()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            _httpClient = new HttpClient(handler)
            {
                Timeout = TimeSpan.FromSeconds(360)
            };
        }

        #endregion


        public async Task<T> PutData<T>(string url, List<KeyValuePair<string, string>> urlParameters = null, object bodyData = null)
        {
            return await RequestData<T>(HttpMethod.Put, url, urlParameters, bodyData);
        }

        public async Task<T> PostData<T>(string url, List<KeyValuePair<string, string>> urlParameters = null, object bodyData = null)
        {
            return await RequestData<T>(HttpMethod.Post, url, urlParameters, bodyData);
        }

        public async Task<T> DeleteData<T>(string url, List<KeyValuePair<string, string>> urlParameters = null, object bodyData = null)
        {
            return await RequestData<T>(HttpMethod.Delete, url, urlParameters, bodyData);
        }

        public async Task<T> GetData<T>(string url, List<KeyValuePair<string, string>> urlParameters = null, object bodyData = null)
        {
            return await RequestData<T>(HttpMethod.Get, url, urlParameters, bodyData);
        }

        private async Task<T> RequestData<T>(HttpMethod method, string url, List<KeyValuePair<string, string>> urlParameters = null, object bodyData = null)
        {
                UriBuilder ub = new UriBuilder(url);
                if (urlParameters != null && urlParameters.Count > 0)
                    ub.Query = new FormUrlEncodedContent(urlParameters).ReadAsStringAsync().Result;

                HttpContent content = null;

                if (bodyData == null)
                {
                    string jsonData = JsonConvert.SerializeObject(bodyData);
                    content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                }

                HttpRequestMessage request = new HttpRequestMessage()
                {
                    Method = method,
                    RequestUri = ub.Uri,
                    Content = content
                };

                HttpResponseMessage response = await _httpClient.SendAsync(request);
                var responseMessage = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);

                return responseMessage;
        }
    }
}
