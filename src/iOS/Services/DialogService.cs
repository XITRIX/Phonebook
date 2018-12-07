using System;
using Phonebook.Core.Services;
using UIKit;
using MvvmCross;
namespace Phonebook.iOS.Services
{
    public class DialogService : IDialogService
    {
        public void CreateOneButtonDialog(string title, string message, string button, Action buttonAction)
        {
            var controller = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
            var action = UIAlertAction.Create(button, UIAlertActionStyle.Default, (handler) => {
                buttonAction();
            });
            controller.AddAction(action);
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(controller, true, null);
        }
    }
}
