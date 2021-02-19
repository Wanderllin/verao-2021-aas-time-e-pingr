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

		[HttpGet]
		public IEnumerable<Ping> Get()
		{
			var rng = new Random();
			return Enumerable.Range(1, 1).Select(index => new Ping
			{
				ID = Guid.NewGuid().ToString(),
				Post = "Governo diz que a vacinação será por ordem de chegada...",
				Tags = "#vacina",
				Imagens = @"C:\Users\Marcos\source\repos\PingQuery\PingQuery\Img\GitHub.png"
			});
			}
	}
}
