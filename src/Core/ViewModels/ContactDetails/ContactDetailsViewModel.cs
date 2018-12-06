using System;
using MvvmCross.ViewModels;
using Phonebook.API.Models;
using Phonebook.Core.ViewModels.Contacts.Items;
namespace Phonebook.Core.ViewModels.ContactDetails
{
    public class ContactDetailsViewModel : MvxViewModel<ContactItemVm>
    {
        private ContactItemVm _contact;

        public string Photo => _contact.Model.Picture.Large;
        public string Name => _contact.FullName;
        public string Phone => _contact.Phone;
        public string Mail => _contact.Mail;

        public override void Prepare(ContactItemVm parameter)
        {
            _contact = parameter;
        }
    }
}
