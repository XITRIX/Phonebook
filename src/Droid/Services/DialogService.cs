using System;
using Android.Support.V7.App;
using MvvmCross;
using MvvmCross.Platforms.Android;
using Phonebook.Core.Services;

namespace Phonebook.Droid.Services
{
    public class DialogService : IDialogService
    {
        public Android.App.Activity CurrentActivity => Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>().Activity;

        public void CreateOneButtonDialog(string title, string message, string button, Action buttonAction)
        {
            var activity = CurrentActivity;
            activity.RunOnUiThread(() =>
            {
                new AlertDialog.Builder(activity).SetTitle(title)
                    .SetMessage(message)
                    .SetPositiveButton(button, (sender, e) =>
                    {
                        buttonAction();
                    }).Show();
            });
        }

        public void CreateOneButtonCancelingDialog(string title, string message, string cancel, string button, Action buttonAction)
        {
            var activity = CurrentActivity;
            activity.RunOnUiThread(() =>
            {
                new AlertDialog.Builder(activity).SetTitle(title)
                    .SetMessage(message)
                    .SetPositiveButton(button, (sender, e) =>
                    {
                        buttonAction();
                    })
                    .SetNegativeButton(cancel, (s, e) => { })
                    .Show();
            });
        }
    }
}
