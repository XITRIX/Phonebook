using System;
using MvvmCross.ViewModels;
using MvvmCross;
using Phonebook.API.Services.Contacts;
using Phonebook.API.Services.DataBase;
using Phonebook.API.Services.Cache;
using Phonebook.API.Services.Reachability;

namespace Phonebook.API
{
    public class App
    {
        public void RegisterServices()
        {
            Mvx.IoCProvider.RegisterSingleton<IDataBaseService>(() => { return new DataBaseService(); });
            Mvx.IoCProvider.RegisterType<ICacheService, CacheService>();
            Mvx.IoCProvider.RegisterType<IContactsService, ContactsService>();
            Mvx.IoCProvider.RegisterType<IReachabilityService, ReachabilityService>();
        }
    }
}
