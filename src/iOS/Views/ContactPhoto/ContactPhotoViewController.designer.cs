// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Phonebook.iOS.Views.ContactPhoto
{
	[Register ("ContactPhotoViewController")]
	partial class ContactPhotoViewController
	{
		[Outlet]
		FFImageLoading.Cross.MvxCachedImageView image { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (image != null) {
				image.Dispose ();
				image = null;
			}
		}
	}
}
