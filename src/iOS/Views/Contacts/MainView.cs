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
using System.Threading.Tasks;
using Phonebook.Core.ViewModels.Contacts;

namespace Phonebook.iOS.Views.Contacts
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class MainView : MvxViewController<MainViewModel>
    {
        ICommand RefreshCommand { get; set; }

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
            set.Bind(this).For(s => s.RefreshCommand).To(vm => vm.RefreshContactsCommand);
            set.Apply();

            AddRefreshControl();

            tableView.Source = source;
            tableView.ReloadData();
        }

        private void AddRefreshControl()
        {
            if (UIDevice.CurrentDevice.CheckSystemVersion(6, 0))
            {
                var refreshControl = new UIRefreshControl();
                refreshControl.ValueChanged += (sender, e) =>
                {
                    refreshControl.BeginRefreshing();
                    if (RefreshCommand?.CanExecute(null) ?? false)
                    { //TODO: RefreshCommand == null, need to fix it!
                        RefreshCommand.Execute(null);
                    }
                    refreshControl.EndRefreshing();
                };
                tableView.Add(refreshControl);
            }
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

