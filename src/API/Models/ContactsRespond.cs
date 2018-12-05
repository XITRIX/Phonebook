using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Phonebook.API.Models
{
    public class ContactsRespond
    {
        [JsonProperty("results")]
        public List<User> Contacts;

        public InfoModel Info;
    }
}
