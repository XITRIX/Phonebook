using System;

using UIKit;
using MvvmCross.Platforms.Ios.Views;
using Phonebook.Core.ViewModels.ContactDetails;
using MvvmCross.Binding.BindingContext;

namespace Phonebook.iOS.Views.ContactDetails
{
    public partial class ContactDetailsViewController : MvxViewController<ContactDetailsViewModel>
    {
        public ContactDetailsViewController() : base("ContactDetailsViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<ContactDetailsViewController, ContactDetailsViewModel>();
            set.Bind(image).For(i => i.ImagePath).To(vm => vm.Photo);
            set.Bind(name).To(vm => vm.Name);
            set.Bind(phone).To(vm => vm.Phone);
            set.Bind(mail).To(vm => vm.Mail);
            set.Apply();
        }
    }
}

