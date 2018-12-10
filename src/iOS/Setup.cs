using System.Net.Http;
using MvvmCross;
using MvvmCross.Platforms.Ios.Core;
using Phonebook.API;
using Phonebook.API.Services.Connection;
using Phonebook.Core.Services;
using Phonebook.iOS.Services;
using Phonebook.API.Services.Cache;
using Phonebook.API.Services.Reachability;

namespace Phonebook.iOS
{
    public class Setup : MvxIosSetup<Core.App>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Mvx.IoCProvider.RegisterSingleton<IConnectionService>(() => new ConnectionService(CreateHandler()));
            Mvx.IoCProvider.RegisterSingleton<IDialogService>(() => new DialogService());
        }

        private CachableHttpMessageHandler CreateHandler() {
            return new CachableHttpMessageHandler(new NSUrlSessionHandler(), Mvx.IoCProvider.Resolve<ICacheService>(), Mvx.IoCProvider.Resolve<IReachabilityService>());
        }
    }
}
