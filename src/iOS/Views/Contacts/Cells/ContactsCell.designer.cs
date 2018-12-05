// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Phonebook.iOS.Views.Contacts.Cells
{
    [Register ("ContactsCell")]
    partial class ContactsCell
    {
        [Outlet]
        FFImageLoading.Cross.MvxCachedImageView image { get; set; }

        [Outlet]
        UIKit.UILabel title { get; set; }
        
        void ReleaseDesignerOutlets ()
        {
            if (title != null) {
                title.Dispose ();
                title = null;
            }

            if (image != null) {
                image.Dispose ();
                image = null;
            }
        }
    }
}
