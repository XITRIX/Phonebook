using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using Phonebook.Core.ViewModels.Contacts.Items;
using UIKit;

namespace Phonebook.iOS.Views.Contacts.Cells
{
    public partial class ContactsCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("ContactsCell");
        public static readonly UINib Nib;

        static ContactsCell()
        {
            Nib = UINib.FromName("ContactsCell", NSBundle.MainBundle);
        }

        protected ContactsCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<ContactsCell, ContactItemVm>();

                set.Bind(title).To(vm => vm.FullName);
                set.Bind(image).For(i => i.ImagePath).To(vm => vm.PhotoPath);

                set.Apply();
            });
        }
    }
}
