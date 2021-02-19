using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PingQuery.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PingController : ControllerBase
	{

		private readonly ILogger<PingController> _logger;

		public PingController(ILogger<PingController> logger)
		{
			_logger = logger;
		}

		[HttpGet("byId")]
		public IEnumerable<Ping> GetId(string id)
		{
			var rng = new Random();
			return Enumerable.Range(1, 1).Select(index => new Ping
			{
				id = Guid.NewGuid().ToString(),
				idAccount = Guid.NewGuid().ToString(),
				post = "Governo diz que a vacinação será por ordem de chegada...",
				tags = new string[3] { "#vacina", "#idoso", "#governo"},
				imagens = new string[2] { @"C:\Users\Marcos\source\repos\PingQuery\PingQuery\Img\Vacina.png", @"C:\Users\Marcos\source\repos\PingQuery\PingQuery\Img\Covid19.jpg" },
				visibilidade = "publico"
			});
		}

		[HttpGet("byId")]
		public IEnumerable<Ping> GetAccount(string id)
		{
			var rng = new Random();
			return Enumerable.Range(1, 1).Select(index => new Ping
			{
				id = Guid.NewGuid().ToString(),
				idAccount = Guid.NewGuid().ToString(),
				post = "Governo diz que a vacinação será por ordem de chegada...",
				tags = new string[3] { "#vacina", "#idoso", "#governo" },
				imagens = new string[2] { @"C:\Users\Marcos\source\repos\PingQuery\PingQuery\Img\Vacina.png", @"C:\Users\Marcos\source\repos\PingQuery\PingQuery\Img\Covid19.jpg" },
				visibilidade = "publico"
			});
		}
	}
}
