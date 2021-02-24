using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using web_api_gateway.Model;

namespace web_api_gateway.Infrastructure
{
    public class NotificationDelivertApiClient : ApiClientBase
    {
        public IEnumerable<string> GetNotifications(string user)
        {
            var url = "http://localhost:3000/getNotifications";
            //var notificacoes = new List<string>() { "Notificação 1", "Notificação 2 " };
            var notificacoes = PostAsync<IEnumerable<string>>(url, new { cdUser = user }).Result;
            return notificacoes;
        }
    }
}
