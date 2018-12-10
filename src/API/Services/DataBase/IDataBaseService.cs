using System;
namespace Phonebook.API.Services.DataBase
{
    public interface IDataBaseService
    {
        void Save(string key, string data);

        string LoadString(string key);
    }
}
