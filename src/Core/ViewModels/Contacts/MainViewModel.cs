using System.Threading.Tasks;
using MvvmCross.ViewModels;
using Phonebook.API.Services.Contacts;
using Phonebook.Core.ViewModels.Contacts.Items;
using System.Linq;
using System;
using Phonebook.API.Models;
using System.Net;
using System.Xml.Linq;
using MvvmCross.Commands;

namespace Phonebook.Core.ViewModels.Contacts
{
    public class MainViewModel : MvxViewModel
    {
        private const int COUNT = 10;
        private int page;

        public string Title => "Contacts";
        public MvxAsyncCommand LoadContactsCommand => new MvxAsyncCommand(LoadContacts);
        public MvxAsyncCommand RefreshContactsCommand => new MvxAsyncCommand(RefreshContacts);

        private MvxObservableCollection<ContactItemVm> _items;
        public MvxObservableCollection<ContactItemVm> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        protected IContactsService ContactsService { get; set; }

        public MainViewModel(IContactsService contactsService)
        {
            ContactsService = contactsService;
            Items = new MvxObservableCollection<ContactItemVm>();
        }

        private async Task LoadContacts()
        {
            try
            {
                var result = await ContactsService.GetContacts(++page, COUNT).ConfigureAwait(false);

                if (result == null)
                {
                    //TODO: handle
                }

                var dataSource = new MvxObservableCollection<ContactItemVm>(result.results.Select(SetupItem));
                Items.AddRange(dataSource);
            }
            catch (System.Exception ex)
            {
                //TODO: handle
            }
        }

        private async Task RefreshContacts()
        {
            page = 0;
            Items.Clear();
            await LoadContacts();
        }

        private ContactItemVm SetupItem(User model)
        {
            return new ContactItemVm(model);
        }

        public override async void ViewAppeared()
        {
            base.ViewAppeared();
            await LoadContacts();
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
