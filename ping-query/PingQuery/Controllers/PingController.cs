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

		/// <summary>
		/// Pega um ping específico
		/// </summary>
		/// <returns></returns>
		[HttpGet("")]
		public IEnumerable<Ping> Get(string idPing)
		{
			return Enumerable.Range(1, 1).Select(index => new Ping
			{
				idPing = Guid.NewGuid().ToString(),
				idAccount = Guid.NewGuid().ToString(),
				nameAccount = "Renato",
				dataPost = "19/02/2021 16:05",
				post = "Governo diz que a vacinação será por ordem de chegada...",
				tags = new string[3] { "#vacina", "#idoso", "#governo"},
				imagens = new string[2] { @"C:\Users\Marcos\source\repos\PingQuery\PingQuery\Img\Vacina.png", @"C:\Users\Marcos\source\repos\PingQuery\PingQuery\Img\Covid19.jpg" },
				visibilidade = "publico"
			});
		}
	}
}
