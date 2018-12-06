using MvvmCross;
using MvvmCross.Platforms.Android.Core;
using Phonebook.API;
using Phonebook.API.Services.Connection;
using Xamarin.Android.Net;
using MvvmCross.Platforms.Android.Presenters;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace Phonebook.Droid
{
    public class Setup : MvxAndroidSetup<Core.App>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Mvx.IoCProvider.RegisterSingleton<IConnectionService>(() => new ConnectionService(new AndroidClientHandler()));
        }

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            return new MvxAppCompatViewPresenter(AndroidViewAssemblies);
        }
    }
}
