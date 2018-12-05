using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Phonebook.API.Models
{
    public class RequestResult
    {
        public HttpContent Data;

        public HttpStatusCode ResponseCode;

        public IDictionary<string, IEnumerable<string>> ResponseHeaders;

        public Uri Uri;
    }
}
