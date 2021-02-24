using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api_gateway.Infrastructure;
using System.Net.Http;
using web_api_gateway.Model;

namespace web_api_gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        [HttpPost]
        public IActionResult Ping(Ping ping)
        {
            var pingclient = new PingCommandApiClient();
            pingclient.PostPing(ping);
            return Ok();
        }

        [HttpGet]
        public IEnumerable<Ping> MainFeed(string user)
        {
            var pingclient = new PingQueryApiClient();
            return pingclient.GetPings(user);
        }

        [HttpGet]
        public IEnumerable<Ping> CustomFeed(string user, int customFeedId)
        {
            var accountClient = new AccountApiClient();
            var customFeedConfig = accountClient.GetCustomFeedConfig(user, customFeedId);

            var pingclient = new PingQueryApiClient();
            return pingclient.GetPings(user, customFeedConfig);
        }
    }
}
