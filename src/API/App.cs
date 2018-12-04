using System;
using MvvmCross.ViewModels;
using MvvmCross;
using Phonebook.API.Services.Contacts;

namespace Phonebook.API
{
    public class App
    {
        public void RegisterServices()
        {
            Mvx.IoCProvider.RegisterType<IContactsService, ContactsService>();
        }
    }
}
