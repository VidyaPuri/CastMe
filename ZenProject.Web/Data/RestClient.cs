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

        /// <summary>
        /// Get this to configuration.json file - one day
        /// </summary>
        public string ApiUrl { get; set; } = "https://localhost:44376/api";

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

        private async Task<T> PutData<T>(string url, List<KeyValuePair<string, string>> urlParameters = null, object bodyData = null)
        {
            return await RequestData<T>(HttpMethod.Put, url, urlParameters, bodyData);
        }

        private async Task<T> PostData<T>(string url, List<KeyValuePair<string, string>> urlParameters = null, object bodyData = null)
        {
            return await RequestData<T>(HttpMethod.Post, url, urlParameters, bodyData);
        }

        private async Task<T> DeleteData<T>(string url, List<KeyValuePair<string, string>> urlParameters = null, object bodyData = null)
        {
            return await RequestData<T>(HttpMethod.Delete, url, urlParameters, bodyData);
        }

        private async Task<T> GetData<T>(string url, List<KeyValuePair<string, string>> urlParameters = null, object bodyData = null)
        {
            return await RequestData<T>(HttpMethod.Get, url, urlParameters, bodyData);
        }

        private async Task<T> RequestData<T>(HttpMethod method, string url, List<KeyValuePair<string, string>> urlParameters = null, object bodyData = null)
        {
            try
            {
                UriBuilder ub = new UriBuilder(url);
                if (urlParameters != null && urlParameters.Count > 0)
                    ub.Query = new FormUrlEncodedContent(urlParameters).ReadAsStringAsync().Result;

                HttpContent content = null;

                if (bodyData != null)
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
                string jsonResponse = response.Content.ReadAsStringAsync().Result;

                T responseMessage = JsonConvert.DeserializeObject<T>(jsonResponse);

                return responseMessage;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
               
        }
    }
}
