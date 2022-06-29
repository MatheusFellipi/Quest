using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quest.Data;
using Quest.Models;


namespace Quest.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		[HttpPost]
		[Route("login")]
		[AllowAnonymous]

		public async void /*Task<ActionResult<dynamic>>*/ Autheticate([FromBody] User model)
		{
		}

	}
}
