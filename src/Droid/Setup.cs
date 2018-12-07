using MvvmCross;
using MvvmCross.Droid.Support.V7.AppCompat;
using Phonebook.API;
using Phonebook.API.Services.Connection;
using Phonebook.Core.Services;
using Phonebook.Droid.Services;
using Xamarin.Android.Net;

namespace Phonebook.Droid
{
    public class Setup : MvxAppCompatSetup<Core.App>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Mvx.IoCProvider.RegisterSingleton<IConnectionService>(() => new ConnectionService(new AndroidClientHandler()));
            Mvx.IoCProvider.RegisterSingleton<IDialogService>(() => new DialogService());
        }
    }
}
