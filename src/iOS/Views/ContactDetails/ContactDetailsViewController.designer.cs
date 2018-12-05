// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Phonebook.iOS.Views.ContactDetails
{
	[Register ("ContactDetailsViewController")]
	partial class ContactDetailsViewController
	{
		[Outlet]
		FFImageLoading.Cross.MvxCachedImageView image { get; set; }

		[Outlet]
		UIKit.UILabel mail { get; set; }

		[Outlet]
		UIKit.UILabel name { get; set; }

		[Outlet]
		UIKit.UILabel phone { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (image != null) {
				image.Dispose ();
				image = null;
			}

			if (mail != null) {
				mail.Dispose ();
				mail = null;
			}

			if (name != null) {
				name.Dispose ();
				name = null;
			}

			if (phone != null) {
				phone.Dispose ();
				phone = null;
			}
		}
	}
}
