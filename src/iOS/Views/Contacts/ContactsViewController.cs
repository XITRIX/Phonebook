
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using Phonebook.Core.Models;
using Phonebook.Core.ViewModels.Contacts;
using Phonebook.iOS.Views.Contacts.Cells;
using Realms;
using UIKit;

namespace Phonebook.iOS.Views.Contacts
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class ContactsViewController : MvxViewController<ContactsViewModel>
    {
        MvxUIRefreshControl _refreshControl;
        UIActivityIndicatorView loadingIndicator;

        public ContactsViewController()
            : base(nameof(ContactsViewController), null)
        {
        }

        private void Binding()
        {
            var source = new ContactsTableSource(tableView, ContactsCell.Key);

            var set = this.CreateBindingSet<ContactsViewController, ContactsViewModel>();

            set.Bind(source).To(vm => vm.Items);
            set.Bind(source).For(s => s.PagingCommand).To(vm => vm.LoadContactsCommand);
            set.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.NavigateToDetailsCommand);

            set.Bind(this).For(s => s.Title).To(vm => vm.Title);

            set.Bind(_refreshControl).For(s => s.IsRefreshing).To(vm => vm.IsRefreshing);
            set.Bind(_refreshControl).For(s => s.RefreshCommand).To(vm => vm.RefreshContactsCommand);
            set.Bind(loadingIndicator).For(s => s.Hidden).To(vm => vm.IsLoading).WithConversion("Bool");

            set.Apply();

            tableView.Source = source;
            tableView.ReloadData();
        }

        private void AddLoadingIndicatorFooter() {
            loadingIndicator = new UIActivityIndicatorView
            {
                ActivityIndicatorViewStyle = UIActivityIndicatorViewStyle.WhiteLarge,
                Color = UIColor.Black
            };
            loadingIndicator.Frame = new CoreGraphics.CGRect(0, 0, tableView.Bounds.Width, 44);
            tableView.TableFooterView = loadingIndicator;
        }

        private void AddRefreshControl()
        {
            _refreshControl = new MvxUIRefreshControl();

            if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
            {
                tableView.RefreshControl = _refreshControl;
            }
            else
            {
                tableView.Add(_refreshControl);
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            AddRefreshControl();
            AddLoadingIndicatorFooter();

            Binding();
        }
    }
}

