using System;
using System.Net.Http;
using System.Threading.Tasks;
using MvvmCross;
using Phonebook.API.Models;

namespace Phonebook.API.Services.Contacts
{
    public class ContactsService : BaseService, IContactsService
    {
        public ContactsService(IConnectionService connectionService) 
        : base(connectionService)
        {
        }

        public async Task<ContactsRespond> GetContacts(int page, int count)
        {
            return await Get<ContactsRespond>(new Uri($"{ApiConstants.RandomUserUrl}?page={page}&results={count}&seed=1"));
        }
    }
}
