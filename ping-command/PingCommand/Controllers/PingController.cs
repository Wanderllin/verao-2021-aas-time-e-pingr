using Microsoft.AspNetCore.Mvc;
using PingCommand.Infrastructure;
using System.Collections.Generic;

namespace PingCommand.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PingController : ControllerBase
	{
		private readonly ICacheProvider<Ping> _cacheProvider;

		public PingController(ICacheProvider<Ping> provider)
		{
			_cacheProvider = provider;
		}

		/// <summary>
		/// Posta um ping
		/// </summary>
		/// <returns></returns>
		[HttpPost("")]
		public IActionResult Post(Ping ping)
		{
			List<Ping> pings = _cacheProvider.GetAll("pings");
			pings.Add(ping);
			_cacheProvider.AddAll("pings", pings);

			return Created("", ping);
		}
	}
}
