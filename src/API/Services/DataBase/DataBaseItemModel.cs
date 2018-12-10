using System;
using Realms;
namespace Phonebook.API.Services.DataBase
{
    public class DataBaseStringItemModel : RealmObject
    {
        [PrimaryKey]
        public string Key { get; set; }

        public string Data { get; set; }

        public DataBaseStringItemModel() { }

        public DataBaseStringItemModel(string key, string data)
        {
            Key = key;
            Data = data;
        }
    }
}
