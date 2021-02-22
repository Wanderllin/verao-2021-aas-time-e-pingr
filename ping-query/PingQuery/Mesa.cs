using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PingQuery
{
	public class Mesa
	{
		public string idAccount { get; set; }

		public List<Ping> listaDePings { get; set; }

		public string tipoDeMesa { get; set; }

		public string nomeMesa { get; set; }
	}
}
