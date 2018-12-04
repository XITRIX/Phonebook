using System;
using Phonebook.API.Models;
using Phonebook.API;
namespace Phonebook.Core.ViewModels.Contacts.Items
{
    public class ContactItemVm
    {
        public User model;
        public ContactItemVm(User model)
        {
            this.model = model;
        }

        public string FullName => $"{model.Name.last.FirstCharToUpper()} {model.Name.first.FirstCharToUpper()}";
        public string PhotoPath => model.Picture.large;
    }
}
