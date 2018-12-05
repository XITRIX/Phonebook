using System;
using System.Net.Http;
using System.Threading.Tasks;
using Phonebook.API.Models;

namespace Phonebook.API
{
    public interface IConnectionService
    {
        Task<RequestResult> Get(Uri uri);

        Task<RequestResult> Post(Uri uri, HttpContent httpContent);
    }
}
