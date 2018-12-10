using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MvvmCross;
using System;
using Phonebook.API.Services.Reachability;

namespace Phonebook.API.Services.Cache
{
    public class CachableHttpMessageHandler : HttpMessageHandler
    {
        private readonly HttpMessageInvoker _handlerInvoker;
        private readonly ICacheService _cacheService;
        private readonly IReachabilityService _reachabilityService;

        public CachableHttpMessageHandler(HttpMessageHandler handler, ICacheService cacheService, IReachabilityService reachabilityService)
        {
            _handlerInvoker = new HttpMessageInvoker(handler);
            _cacheService = cacheService;
            _reachabilityService = reachabilityService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage result = null;

            if (!_reachabilityService.IsConnected())
            {
                result = await _cacheService.GetCachedRequest(request.RequestUri.AbsoluteUri).ConfigureAwait(false);
            }
            else
            {
                result = await _handlerInvoker.SendAsync(request, cancellationToken).ConfigureAwait(false);

                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    await _cacheService.CacheRequestAsync(result).ConfigureAwait(false);
            }

            return result;
        }
    }
}
