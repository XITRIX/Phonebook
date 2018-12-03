using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Phonebook.API.Models;
namespace Phonebook.API.Services
{
    public abstract class BaseService
    {
        protected IConnectionService ConnectionService { get; }

        BaseService(IConnectionService connectionService) {
            ConnectionService = connectionService;
        }

        public async Task<T> Get<T>(Uri uri)
            where T : class, new()
        {
            var requestResult = await ConnectionService.Get(uri);
            return await ParseResult<T>(requestResult);
        }

        public async Task<T> Post<T>(Uri uri, HttpContent httpContent)
            where T : class, new()
        {
            var requestResult = await ConnectionService.Post(uri, httpContent);
            return await ParseResult<T>(requestResult);
        }

        private async Task<T> ParseResult<T>(RequestResult requestResult)
            where T : class, new()
        {
            if (requestResult.ResponseCode == System.Net.HttpStatusCode.OK)
            {
                var result = await requestResult.Data.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(result);
            }
            return default(T);
        }
    }
}
