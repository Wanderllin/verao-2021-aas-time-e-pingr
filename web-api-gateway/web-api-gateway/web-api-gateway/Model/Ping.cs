using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_api_gateway.Model
{
    public class Ping
    {
		public string idPing { get; set; }

		public string idAccount { get; set; }

		public string nameAccount { get; set; }

		public string dataPost { get; set; }

		public string post { get; set; }

		public string[] tags { get; set; }

		public string[] imagens { get; set; }

		public string visibilidade { get; set; }
	}
}
