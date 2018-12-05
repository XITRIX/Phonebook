// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Phonebook.iOS.Views.Contacts
{
    [Register("ContactsViewController")]
    partial class ContactsViewController
    {
        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        UIKit.UITableView tableView { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (tableView != null)
            {
                tableView.Dispose();
                tableView = null;
            }
        }
    }
}
