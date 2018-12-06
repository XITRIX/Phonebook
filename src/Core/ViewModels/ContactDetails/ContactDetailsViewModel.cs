using System;
using MvvmCross.ViewModels;
using Phonebook.API;
using Phonebook.API.Models;
using Phonebook.Core.ViewModels.Contacts.Items;
namespace Phonebook.Core.ViewModels.ContactDetails
{
    public class ContactDetailsViewModel : MvxViewModel<User>
    {
        private User _contact;

        public string PhotoPath => _contact.Picture.Large;
        public string Name => $"{_contact.Name.Last.FirstCharToUpper()} {_contact.Name.First.FirstCharToUpper()}";
        public string Mail => _contact.Email;
        public string Phone => _contact.Phone;

        public override void Prepare(User parameter)
        {
            _contact = parameter;
        }
    }
}
