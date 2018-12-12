using System;
using System.Threading.Tasks;
namespace Phonebook.API.Services.DataBase
{
    public interface IDataBaseService
    {
        Task Save(string key, string data);

        Task<string> LoadString(string key);

        Task ClearAll();
    }
}
