using System;
using Phonebook.API.Models;
using Phonebook.API;
namespace Phonebook.Core.ViewModels.Contacts.Items
{
    public class ContactItemVm
    {
        public User Model { get; set; }
        public ContactItemVm(User model)
        {
            this.Model = model;
        }

        public string FullName => $"{Model.Name.Last.FirstCharToUpper()} {Model.Name.First.FirstCharToUpper()}";
        public string PhotoPath => Model.Picture.Thumbnail;
        public string Mail => Model.Email;
        public string Phone => Model.Phone;
    }
}
