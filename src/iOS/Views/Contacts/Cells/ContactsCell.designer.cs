// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
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
            if (image != null) {
                image.Dispose ();
                image = null;
            }

            if (title != null) {
                title.Dispose ();
                title = null;
            }
        }
    }
}