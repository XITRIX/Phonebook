using System;

using UIKit;
using MvvmCross.Platforms.Ios.Views;
using Phonebook.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Binding.Views;
using Foundation;
using System.Collections.Generic;
using Phonebook.Core.ViewModels.Contacts.Items;
using CoreText;
using MvvmCross.Commands;
using MvvmCross.Binding.Bindings.Target;
using System.Windows.Input;
using Phonebook.iOS.Views.Contacts.Cells;

namespace Phonebook.iOS.Views.Contacts
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class MainView : MvxViewController<MainViewModel>
    {
        public MainView()
        : base("MainView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var source = new ContactsTableSource(tableView, ContactsCell.Key);

            var set = this.CreateBindingSet<MainView, MainViewModel>();
            set.Bind(source).To(vm => vm.Items);
            set.Bind(source).For(s => s.PagingCommand).To(vm => vm.LoadContactsCommand);
            set.Bind(this).For(s => s.Title).To(vm => vm.Title);
            set.Apply();

            tableView.Source = source;
            tableView.ReloadData();
        }
    }

    public class ContactsTableSource : MvxSimpleTableViewSource
    {
        public ICommand PagingCommand { get; set; }

        public ContactsTableSource(IntPtr handle)
        : base(handle)
        {
        }

        public ContactsTableSource(UITableView tableView, string nibName, string cellIdentifier = null, NSBundle bundle = null)
        : base(tableView, nibName, cellIdentifier, bundle)
        {
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            if (indexPath.Row >= RowsInSection(tableView, indexPath.Section) - 5 &&
                (PagingCommand?.CanExecute(null) ?? false))
            {
                PagingCommand.Execute(null);
            }

            return base.GetOrCreateCellFor(tableView, indexPath, item);
        }
    }
}

