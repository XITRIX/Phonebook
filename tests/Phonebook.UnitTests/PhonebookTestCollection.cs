using System;
using MvvmCross.Tests;
using Moq;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Xunit;
using Phonebook.API.Services.DataBase;
using MvvmCross.IoC;
using Phonebook.API.Services.Cache;
using System.Net.Http;
using Phonebook.UnitTests.TestObjects;
using Phonebook.API.Services.Reachability;
namespace Phonebook.UnitTests
{
    [CollectionDefinition("MvxTest")]
    public class MvxTestCollection : ICollectionFixture<PhonebookTestFixture>
    {

    }

    public class PhonebookTestFixture : MvxTestFixture
    {
        public IDataBaseService DataBaseService => Ioc.Resolve<IDataBaseService>();
        public ICacheService CacheService => Ioc.Resolve<ICacheService>();
        public IReachabilityService ReachabilityService => Ioc.Resolve<IReachabilityService>();
        public HttpMessageHandler CachableHttpMessageHandler => Ioc.Resolve<CachableHttpMessageHandler>();

        protected override void AdditionalSetup()
        {
            var navigationServiceMock = new Mock<IMvxNavigationService>();

            Ioc.RegisterSingleton(navigationServiceMock.Object);
            Ioc.RegisterSingleton(new MvxDefaultViewModelLocator(navigationServiceMock.Object));

            Ioc.LazyConstructAndRegisterSingleton<IDataBaseService, DataBaseService>();
            Ioc.LazyConstructAndRegisterSingleton<ICacheService, CacheService>();
            Ioc.LazyConstructAndRegisterSingleton<IReachabilityService, ReachabilityService>();

            Ioc.RegisterSingleton(new CachableHttpMessageHandler(new MockHttpMessageHandler(true), CacheService, ReachabilityService));
        }

        public override void ClearAll(IMvxIocOptions options = null)
        {
            base.ClearAll(options);

            DataBaseService?.ClearAll();
        }
    }
}
