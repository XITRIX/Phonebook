using System;

using UIKit;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.Binding.BindingContext;
using Phonebook.Core.ViewModels.ContactPhoto;

namespace Phonebook.iOS.Views.ContactPhoto
{
    public partial class ContactPhotoViewController : MvxViewController<ContactPhotoViewModel>
    {
        public ContactPhotoViewController() : base("ContactPhotoViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<ContactPhotoViewController, ContactPhotoViewModel>();
            set.Bind(image).For(s => s.ImagePath).To(vm => vm.PhotoPath);
            set.Apply();
        }
    }
}

