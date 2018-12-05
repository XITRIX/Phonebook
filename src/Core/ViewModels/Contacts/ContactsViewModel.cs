using System;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using Phonebook.API.Models;
using Phonebook.API.Services.Contacts;
using Phonebook.Core.ViewModels.Contacts.Items;

namespace Phonebook.Core.ViewModels.Contacts
{
    public class ContactsViewModel : MvxViewModel
    {
        private const int COUNT = 10;
        private int _page = 1;

        public string Title => "Contacts";

        private IMvxCommand _loadContactsCommand;
        public IMvxCommand LoadContactsCommand => _loadContactsCommand ?? (_loadContactsCommand = new MvxAsyncCommand(LoadContacts, () => !IsLoading));

        private IMvxCommand _refreshContactsCommand;
        public IMvxCommand RefreshContactsCommand => _refreshContactsCommand ?? (_refreshContactsCommand = new MvxAsyncCommand(RefreshContacts));

        private MvxObservableCollection<ContactItemVm> _items;
        public MvxObservableCollection<ContactItemVm> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        protected IContactsService ContactsService { get; set; }

        public ContactsViewModel(IContactsService contactsService)
        {
            ContactsService = contactsService;

            Items = new MvxObservableCollection<ContactItemVm>();
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        private async Task LoadContacts()
        {
            IsLoading = true && !IsRefreshing;

            try
            {
                var result = await ContactsService.GetContacts(_page, COUNT).ConfigureAwait(false);

                if (result == null || !result.Contacts.Any())
                {
                    //TODO:
                    return;
                }

                _page++;

                var dataSource = new MvxObservableCollection<ContactItemVm>(result.Contacts.Select(SetupItem));

                Items.AddRange(dataSource);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task RefreshContacts()
        {
            if (IsLoading)
                return;

            IsRefreshing = true;

            ResetItems();

            await LoadContacts();

            IsRefreshing = false;
        }

        private void ResetItems()
        {
            _page = 1;

            Items.Clear();
        }

        private ContactItemVm SetupItem(User model)
        {
            return new ContactItemVm(model);
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();

            Task.Run(LoadContacts);
        }

        // TODO: uncomment when closed 
        // https://github.com/MvvmCross/MvvmCross/pull/3222
        // https://github.com/MvvmCross/MvvmCross/issues/3209
        //public override Task Initialize()
        //{
        //    return LoadContacts();
        //}
    }
}
