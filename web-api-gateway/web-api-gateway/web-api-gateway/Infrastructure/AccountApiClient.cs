using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace web_api_gateway.Infrastructure
{
    public class AccountApiClient: ApiClientBase
    {
        public void FollowUser(string originUser, string destinationUser)
        {
            var url = $"http://localhost:8090/ime-rest/rest/service/followdestination/get/{destinationUser}";
            var response = PostAsync<HttpResponseMessage>(url, new { evento = "NewFollower", originUser = originUser, destinationUser = destinationUser }).Result;
        }

        public object GetCustomFeedConfig(string user, int customFeedId)
        {
            var url = $"http://localhost:8090/ime-rest/rest/service/user/{user}/customfeedconfig/{customFeedId}";
            return PostAsync<HttpResponseMessage>(url).Result;
        }
    }
}
