using System;
using MvvmCross.ViewModels;
using Phonebook.Core.ViewModels;

namespace Phonebook.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            new API.App().RegisterServices();

            RegisterAppStart<MainViewModel>();
        }
    }
}
