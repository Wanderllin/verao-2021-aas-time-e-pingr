using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api_gateway.Infrastructure;
using System.Net.Http;

namespace web_api_gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> GetNotitications(string user)
        {
            var notificationClient = new NotificationDelivertApiClient();
            return notificationClient.GetNotifications(user);
        }
    }
}
