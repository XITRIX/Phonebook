using System;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Phonebook.API.Models;
using Phonebook.API.Services.Contacts;
using Phonebook.Core.Services;
using Phonebook.Core.ViewModels.ContactDetails;
using Phonebook.Core.ViewModels.Contacts.Items;
using System.Collections.Generic;
using Realms;
using Phonebook.Core.Models;
using Newtonsoft.Json;
using System.Threading;

namespace Phonebook.Core.ViewModels.Contacts
{
    public class ContactsViewModel : MvxViewModel
    {
        private const int COUNT = 10;

        private int _page = 1;

        private Realm _realm;
        private readonly IMvxNavigationService _navigationService;
        private readonly IContactsService _contactsService;
        private readonly IDialogService _dialogService;

        public string Title => "Contacts";

        private IMvxCommand _loadContactsCommand;
        public IMvxCommand LoadContactsCommand => _loadContactsCommand ?? (_loadContactsCommand = new MvxAsyncCommand(LoadContacts, () => !IsLoading));

        private IMvxCommand _refreshContactsCommand;
        public IMvxCommand RefreshContactsCommand => _refreshContactsCommand ?? (_refreshContactsCommand = new MvxAsyncCommand(RefreshContacts));

        private IMvxAsyncCommand<ContactItemVm> _navigateToDetailsCommand;
        public IMvxAsyncCommand<ContactItemVm> NavigateToDetailsCommand => _navigateToDetailsCommand ?? (_navigateToDetailsCommand = new MvxAsyncCommand<ContactItemVm>(NavigateToDetails));

        private MvxObservableCollection<ContactItemVm> _items;
        public MvxObservableCollection<ContactItemVm> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public ContactsViewModel(IMvxNavigationService navigationService, IContactsService contactsService, IDialogService dialogService)
        {
            _contactsService = contactsService;
            _navigationService = navigationService;
            _dialogService = dialogService;

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
                var result = await _contactsService.GetContacts(_page, COUNT).ConfigureAwait(false);

                MvxObservableCollection<ContactItemVm> dataSource;
                if (result == null || !result.Contacts.Any())
                {
                    _dialogService.CreateOneButtonCancelingDialog("Error", "Error retrieving data from server, check your internet connection", "Close", "Reload", async () => { await RefreshContacts(); });
                    return;
                }
                dataSource = new MvxObservableCollection<ContactItemVm>(result.Contacts.Select(SetupItem));
                var localPage = _page;

                _page++;

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

        private Task<bool> NavigateToDetails(ContactItemVm item)
        {
            return _navigationService.Navigate<ContactDetailsViewModel, User>(item.Model);
        }

        public override void ViewCreated()
        {
            base.ViewCreated();

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
