using System;
using Xunit;
using Phonebook.API.Services.Cache;
using Phonebook.API.Services.DataBase;
using System.Threading.Tasks;
using System.Net.Http;
using Moq;

namespace Phonebook.UnitTests
{
    [Collection("MvxTest")]
    public class CacheTests
    {
        private readonly PhonebookTestFixture _fixture;

        public CacheTests(PhonebookTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Test_DataBaseService_PutAndGetData()
        {
            _fixture.ClearAll();

            var testModel = new DataBaseStringItemModel("Test key", "Test Message");
            await _fixture.DataBaseService.Save(testModel.Key, testModel.Data);

            var res = await _fixture.DataBaseService.LoadString(testModel.Key);

            Assert.Equal(testModel.Data, res);
        }

        [Fact]
        public async Task Test_DataBaseService_GetEmptyData()
        {
            _fixture.ClearAll();

            var key = "Test_KEY";

            var res = await _fixture.DataBaseService.LoadString(key);

            Assert.Null(res);
        }

        [Fact]
        public async Task Test_DataBaseService_PutAndGetNullData()
        {
            _fixture.ClearAll();

            var testModel = new DataBaseStringItemModel("Test key", null);
            await _fixture.DataBaseService.Save(testModel.Key, testModel.Data);

            var res = await _fixture.DataBaseService.LoadString(testModel.Key);

            Assert.Equal(testModel.Data, res);
        }

        [Fact]
        public async Task Test_DataBaseService_PutAndGetNullKey()
        {
            _fixture.ClearAll();

            var testModel = new DataBaseStringItemModel(null, "Test Message");
            await _fixture.DataBaseService.Save(testModel.Key, testModel.Data);

            var res = await _fixture.DataBaseService.LoadString(testModel.Key);

            Assert.Equal(testModel.Data, res);
        }

        [Fact]
        public async Task Test_CacheService_PutAndGetContent()
        {
            _fixture.ClearAll();

            var testRequest = new HttpRequestMessage(HttpMethod.Get, "http://www.testUri.onion");
            var testContent = new StringContent("Test content");
            var testResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK) {
                RequestMessage = testRequest,
                Content = testContent
            };

            await _fixture.CacheService.CacheRequestAsync(testResponse);
            var res = await _fixture.CacheService.GetCachedRequest(testRequest.RequestUri.AbsoluteUri);

            Assert.Equal(await testContent.ReadAsStringAsync(), await res.Content.ReadAsStringAsync());
        }

        [Fact]
        public async Task Test_CacheService_PutAndGetNullContent()
        {
            _fixture.ClearAll();

            var testRequest = new HttpRequestMessage(HttpMethod.Get, "http://www.testUri.onion");
            var testResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                RequestMessage = testRequest,
                Content = null
            };

            await _fixture.CacheService.CacheRequestAsync(testResponse);
            var res = await _fixture.CacheService.GetCachedRequest(testRequest.RequestUri.AbsoluteUri);

            Assert.Null(res);
        }

        [Fact]
        public async Task Test_CacheService_PutNullRequest()
        {
            _fixture.ClearAll();

            var testResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = null
            };

            await _fixture.CacheService.CacheRequestAsync(testResponse);
            var res = await _fixture.CacheService.GetCachedRequest(null);

            Assert.Null(res);
        }

        [Fact]
        public void Test_CacheService_CacheHandler()
        {
            _fixture.ClearAll();

            _fixture.CachableHttpMessageHandler
        }
    }
}
