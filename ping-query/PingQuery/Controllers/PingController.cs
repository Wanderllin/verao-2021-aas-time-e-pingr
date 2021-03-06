﻿using Microsoft.AspNetCore.Mvc;
using PingQuery.Infrastructure;
using System.Collections.Generic;

namespace PingQuery.Controllers
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
		/// Pega um ping específico
		/// </summary>
		/// <returns></returns>
		[HttpGet("")]
		public IEnumerable<Ping> Get()
		{
			return _cacheProvider.GetAll("pings");
		}
	}
}
