using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using Phonebook.Core.ViewModels.ContactDetails;
using MvvmCross.Platforms.Ios.Binding;

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
            set.Bind(image).For(i => i.ImagePath).To(vm => vm.PhotoPath);
            set.Bind(image).For(img => img.BindTap()).To(vm => vm.NavigateToPhotoCommand);
            set.Bind(name).To(vm => vm.Name);
            set.Bind(phone).To(vm => vm.Phone);
            set.Bind(mail).To(vm => vm.Mail);
            set.Apply();
        }
    }
}

