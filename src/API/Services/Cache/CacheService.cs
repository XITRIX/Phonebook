using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Phonebook.API.Services.DataBase;

namespace Phonebook.API.Services.Cache
{
    public class CacheService : ICacheService
    {
        private readonly IDataBaseService _dataBase;

        public CacheService(IDataBaseService dataBase)
        {
            _dataBase = dataBase;
        }

        public async Task CacheRequestAsync(HttpResponseMessage response)
        {
            if (response == null || response.Content == null) { return; }

            var content = await response.Content.ReadAsStringAsync();
            await _dataBase.Save(response.RequestMessage.RequestUri.AbsoluteUri, content);
        }

        public Task<HttpResponseMessage> GetCachedRequest(string uri)
        {
            return Task.Run(async () =>
            {
                var cacheContent = await _dataBase.LoadString(uri);
                if (cacheContent == null) { return null; }

                return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(cacheContent) };
            });
        }
    }
}
