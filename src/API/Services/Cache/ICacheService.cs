using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Phonebook.API.Services.Cache
{
    public interface ICacheService
    {
        Task CacheRequestAsync(HttpResponseMessage response);

        Task<HttpResponseMessage> GetCachedRequest(string uri);
    }
}
