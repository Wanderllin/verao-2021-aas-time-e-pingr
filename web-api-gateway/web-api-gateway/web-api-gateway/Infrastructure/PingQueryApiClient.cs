using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using web_api_gateway.Model;

namespace web_api_gateway.Infrastructure
{
    public class PingQueryApiClient:ApiClientBase
    {
        public IEnumerable<Ping> GetPings(string user)
        {
            var url = $"http://localhost:59171/{user}";
            return GetAsync<IEnumerable<Ping>>(url).Result;
        }

        public IEnumerable<Ping> GetPings(string user, object customFeedConfig)
        {
            var url = $"http://localhost:59171/{user}";
            return PostAsync<IEnumerable<Ping>>(url, customFeedConfig).Result;
        }
    }
}
