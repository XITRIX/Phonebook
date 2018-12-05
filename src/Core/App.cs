using System;
using MvvmCross.ViewModels;
using Phonebook.Core.ViewModels.Contacts;

namespace Phonebook.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            new API.App().RegisterServices();

            RegisterAppStart<ContactsViewModel>();
        }
    }
}
