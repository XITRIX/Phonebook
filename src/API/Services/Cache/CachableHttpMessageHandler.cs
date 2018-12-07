using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Phonebook.API.Services.Cache
{
    //public class CachableHttpMessageHandler : HttpMessageHandler
    //{
    //    // Responses to return
    //    private readonly Queue<HttpResponseMessage> _responses =
    //        new Queue<HttpResponseMessage>();

    //    // Requests that were sent via the handler
    //    private readonly List<HttpRequestMessage> _requests =
    //        new List<HttpRequestMessage>();

    //    private readonly HttpMessageHandler _httpMessageHandler;
    //    public CachableHttpMessageHandler(HttpMessageHandler httpMessageHandler)
    //    {
    //        _httpMessageHandler = httpMessageHandler;

    //        //HttpClient i = new HttpMessageInvoker(httpMessageHandler);
    //        //var c = new HttpClient(i);
    //    }

    //    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    //    {
    //        if(_responses.Count == 0)
    //            throw new InvalidOperationException("No response configured");

    //        _requests.Add(request);
    //        var response = _responses.Dequeue();
    //        return Task.FromResult(response);
    //    }
    //}
}
