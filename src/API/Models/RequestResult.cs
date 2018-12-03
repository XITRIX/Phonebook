using System;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Collections.Generic;

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
