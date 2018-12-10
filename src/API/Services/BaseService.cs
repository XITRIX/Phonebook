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

        protected BaseService(IConnectionService connectionService)
        {
            ConnectionService = connectionService;
        }

        protected virtual async Task<T> Get<T>(Uri uri)
            where T : class, new()
        {
            var requestResult = await ConnectionService.Get(uri);
            return await ParseResult<T>(requestResult);
        }

        protected virtual async Task<T> Post<T>(Uri uri, HttpContent httpContent)
            where T : class, new()
        {
            var requestResult = await ConnectionService.Post(uri, httpContent);
            return await ParseResult<T>(requestResult);
        }

        private async Task<T> ParseResult<T>(RequestResult requestResult)
            where T : class, new()
        {
            Console.WriteLine("BaseService: " + requestResult.ResponseCode);
            if (requestResult.ResponseCode == System.Net.HttpStatusCode.OK)
            {
                var result = await requestResult.Data.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(result);
            }
            return null;
        }
    }
}
