using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using web_api_gateway.Model;

namespace web_api_gateway.Infrastructure
{
    public class PingCommandApiClient : ApiClientBase
    {
        public void PostPing(Ping ping)
        {
            var url = "http://localhost:59171/";
            var response = PostAsync<HttpResponseMessage>(url, ping).Result;
        }
    }
}
