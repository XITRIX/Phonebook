using System;
using Phonebook.Core.Services;
using UIKit;
using MvvmCross;
using CoreFoundation;
namespace Phonebook.iOS.Services
{
    public class DialogService : IDialogService
    {
        public void CreateOneButtonDialog(string title, string message, string button, Action buttonAction)
        {
            DispatchQueue.MainQueue.DispatchAsync(() =>
            {
                var controller = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
                var action = UIAlertAction.Create(button, UIAlertActionStyle.Default, (handler) =>
                {
                    buttonAction();
                });
                controller.AddAction(action);
                UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(controller, true, null);
            });
        }

        public void CreateOneButtonCancelingDialog(string title, string message, string cancel, string button, Action buttonAction)
        {
            DispatchQueue.MainQueue.DispatchAsync(() =>
            {
                var controller = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
                var action = UIAlertAction.Create(button, UIAlertActionStyle.Default, (handler) =>
                {
                    buttonAction();
                });
                controller.AddAction(action);
                controller.AddAction(UIAlertAction.Create(cancel, UIAlertActionStyle.Cancel, (_) => { }));
                UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(controller, true, null);
            });
        }
    }
}
