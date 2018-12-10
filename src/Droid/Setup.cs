using MvvmCross;
using MvvmCross.Droid.Support.V7.AppCompat;
using Phonebook.API;
using Phonebook.API.Services.Connection;
using Phonebook.Core.Services;
using Phonebook.Droid.Services;
using Xamarin.Android.Net;
using Phonebook.API.Services.Cache;
using Phonebook.API.Services.Reachability;

namespace Phonebook.Droid
{
    public class Setup : MvxAppCompatSetup<Core.App>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Mvx.IoCProvider.RegisterSingleton<IConnectionService>(() => new ConnectionService(CreateHandler()));
            Mvx.IoCProvider.RegisterSingleton<IDialogService>(() => new DialogService());
        }

        private CachableHttpMessageHandler CreateHandler()
        {
            return new CachableHttpMessageHandler(new AndroidClientHandler(), Mvx.IoCProvider.Resolve<ICacheService>(), Mvx.IoCProvider.Resolve<IReachabilityService>());
        }
    }
}
