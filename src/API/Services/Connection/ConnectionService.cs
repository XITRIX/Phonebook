using System;
using System.Net.Http;
using Phonebook.API.Models;
using System.Threading.Tasks;
using System.Linq;
namespace Phonebook.API.Services.Connection
{
    public class ConnectionService : IConnectionService
    {
        private readonly Lazy<HttpClient> _httpClient;

        public ConnectionService(HttpMessageHandler messageHandler)
        {
            _httpClient = new Lazy<HttpClient>(() =>
            {
                return new HttpClient(messageHandler);
            });
        }

        public async Task<RequestResult> Get(Uri uri)
        {
            return await SendAsync(uri);
        }

        public async Task<RequestResult> Post(Uri uri, HttpContent httpContent)
        {
            return await SendAsync(uri, httpContent);
        }

        private async Task<RequestResult> SendAsync(Uri uri, HttpContent httpContent = null)
        {
            var requestMessage = new HttpRequestMessage
            {
                RequestUri = uri,
                Content = httpContent,
                Method = httpContent == null ? HttpMethod.Get : HttpMethod.Post
            };

            var response = await _httpClient.Value.SendAsync(requestMessage);

            return new RequestResult()
            {
                Data = response.Content,
                ResponseCode = response.StatusCode,
                ResponseHeaders = response.Headers.ToDictionary(x => x.Key, x => x.Value),
                Uri = uri,
            };
        }
    }
}
