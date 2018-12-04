using System;

using Foundation;
using UIKit;
using FFImageLoading.Cross;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Binding.BindingContext;
using Phonebook.Core.ViewModels.Contacts.Items;

namespace Phonebook.iOS.Views.Contacts.Cells
{
    public partial class ContactsCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("ContactsCell");
        public static readonly UINib Nib;

        public UILabel Title => title;
        public MvxCachedImageView Image => image;

        static ContactsCell()
        {
            Nib = UINib.FromName("ContactsCell", NSBundle.MainBundle);
        }

        protected ContactsCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<ContactsCell, ContactItemVm>();
                set.Bind(Title).For(t => t.Text).To(vm => vm.FullName);
                set.Bind(image).For(i => i.ImagePath).To(vm => vm.PhotoPath);
                set.Apply();
            });
        }
    }
}
