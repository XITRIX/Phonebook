using System;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross;
using Phonebook.API;
using System.Net.Http;
using Phonebook.API.Services.Connection;

namespace Phonebook.iOS
{
    public class Setup : MvxIosSetup<Core.App>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Mvx.IoCProvider.RegisterSingleton<IConnectionService>(() => new ConnectionService(new NSUrlSessionHandler()));
        }
    }
}
