using System;
using System.Threading.Tasks;
using Phonebook.API.Models;

namespace Phonebook.API.Services.Contacts
{
    public interface IContactsService
    {
        Task<ContactsRespond> GetContacts(int page, int count);
    }
}
