using System;
using Android.Support.V7.App;
using Phonebook.Core.Services;
using MvvmCross;
using MvvmCross.Platforms.Android;

namespace Phonebook.Droid.Services
{
    public class DialogService : IDialogService
    {
        public Android.App.Activity CurrentActivity => Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>().Activity;

        public void CreateOneButtonDialog(string title, string message, string button, Action buttonAction)
        {
            new AlertDialog.Builder(CurrentActivity).SetTitle(title)
                .SetMessage(message)
                .SetPositiveButton(button, (sender, e) =>
                {
                    buttonAction();
                })
                .Show();
        }
        public void CreateOneButtonCancelingDialog(string title, string message, string cancel, string button, Action buttonAction)
        {
            new AlertDialog.Builder(CurrentActivity).SetTitle(title)
                .SetMessage(message)
                .SetPositiveButton(button, (sender, e) =>
                {
                    buttonAction();
                })
                .SetNegativeButton(cancel, (s, e) => { })
                .Show();
        }
    }
}
