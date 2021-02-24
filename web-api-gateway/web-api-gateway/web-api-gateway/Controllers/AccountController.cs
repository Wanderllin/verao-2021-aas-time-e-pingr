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
    public class AccountController : ControllerBase
    {
        [HttpPost("{originUser}/followedusers/{destinationUser}")]
        public IActionResult FollowUser(string originUser, string destinationUser)
        {
            var accountClient = new AccountApiClient();
            accountClient.FollowUser(originUser, destinationUser);
            return Ok();
        }
    }
}
