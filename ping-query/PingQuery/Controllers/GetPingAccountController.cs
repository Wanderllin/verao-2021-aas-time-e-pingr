using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PingQuery.Controllers
{
	public class GetPingAccountController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
