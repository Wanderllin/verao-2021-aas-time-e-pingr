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
	public class MesaController : ControllerBase
	{

		private readonly ILogger<MesaController> _logger;

		public MesaController(ILogger<MesaController> logger)
		{
			_logger = logger;
		}

		/// <summary>
		/// Pega todos os pings da minha mesa principal
		/// </summary>
		/// <returns></returns>
		[HttpGet("")]
		public IEnumerable<Mesa> Get(string pTipoDeMesa)
		{

			List<Ping> listaPings = new List<Ping>();
			listaPings.Add(new Ping
			{
				idPing = Guid.NewGuid().ToString(),
				idAccount = Guid.NewGuid().ToString(),
				nameAccount = "Renato",
				dataPost = "19/02/2021 09:00",
				post = "Meu primeiro ping!",
				tags = new string[1] { "#pingo" },
				imagens = new string[0] { },
				visibilidade = "publico"
			});
			listaPings.Add(new Ping
			{
				idPing = Guid.NewGuid().ToString(),
				idAccount = Guid.NewGuid().ToString(),
				nameAccount = "Paulo",
				dataPost = "19/02/2021 09:35",
				post = "E aí João, vamos pingar kkkkk :)",
				tags = new string[1] { "#salve" },
				imagens = new string[0] { },
				visibilidade = "publico"
			});
			listaPings.Add(new Ping
			{
				idPing = Guid.NewGuid().ToString(),
				idAccount = Guid.NewGuid().ToString(),
				nameAccount = "Renato",
				dataPost = "19/02/2021 16:05",
				post = "Governo diz que a vacinação será por ordem de chegada...",
				tags = new string[3] { "#vacina", "#idoso", "#governo" },
				imagens = new string[2] { @"C:\Users\Marcos\source\repos\PingQuery\PingQuery\Img\Vacina.png", @"C:\Users\Marcos\source\repos\PingQuery\PingQuery\Img\Covid19.jpg" },
				visibilidade = "publico"
			});

			return Enumerable.Range(1, 1).Select(index => new Mesa
			{
				idAccount = Guid.NewGuid().ToString(),
				listaDePings = listaPings,
				tipoDeMesa = "0",
				nomeMesa = "Mesa Principal"
			});
		}

	}
}
