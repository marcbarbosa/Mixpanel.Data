using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mixpanel.Data.Interfaces
{
    public interface IHttpClient
    {
        TimeSpan TimeOut { get; set; }

        Task<HttpResponseMessage> GetAsync(string requestUri);

        Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content);
    }

    public class HttpClientWrapper : IHttpClient
    {
        private readonly HttpClient httpClient;

        public HttpClientWrapper()
        {
            httpClient = new HttpClient();
        }

        public async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            return await httpClient.GetAsync(requestUri);
        }

        public async Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
        {
            return await httpClient.PostAsync(requestUri, content);
        }

        public TimeSpan TimeOut
        {
            get { return httpClient.Timeout; }
            set { httpClient.Timeout = value; }
        }
    }
}
