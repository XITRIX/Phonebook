using System;
using System.Collections.Generic;
namespace Phonebook.API.Models
{
    public class ContactsRespond
    {
        public List<User> results;
        public InfoModel info;
    }

    public class InfoModel 
    {
        public int Page { get; set; }
    }
}
