using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Phonebook.UnitTests.TestObjects
{
    public class MockHttpMessageHandler : HttpMessageHandler
    {
        private bool _isGoodResult = true;
        public string Data => _isGoodResult ? "Good result" : "Bad result";

        public MockHttpMessageHandler(bool goodResult) {
            _isGoodResult = goodResult;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return new Task<HttpResponseMessage>(() =>
            {
                return new HttpResponseMessage(_isGoodResult ? System.Net.HttpStatusCode.OK : System.Net.HttpStatusCode.NotFound)
                {
                    Content = new StringContent(Data);
                };
            });
        }
    }
}
