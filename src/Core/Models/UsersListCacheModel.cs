using System.Collections.Generic;
using Phonebook.Core.ViewModels.Contacts.Items;
using Realms;

namespace Phonebook.Core.Models
{
    public class UsersListCacheModel : RealmObject
    {
        [PrimaryKey]
        public int Page { get; set; }
        public string SeriallizedContactItemsList { get; set; }
    }
}
