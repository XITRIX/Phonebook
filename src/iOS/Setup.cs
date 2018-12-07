using System.Net.Http;
using MvvmCross;
using MvvmCross.Platforms.Ios.Core;
using Phonebook.API;
using Phonebook.API.Services.Connection;
using Phonebook.Core.Services;
using Phonebook.iOS.Services;

namespace Phonebook.iOS
{
    public class Setup : MvxIosSetup<Core.App>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Mvx.IoCProvider.RegisterSingleton<IConnectionService>(() => new ConnectionService(new NSUrlSessionHandler()));
            Mvx.IoCProvider.RegisterSingleton<IDialogService>(() => new DialogService());
        }
    }
}
