using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quest.Data;
using Quest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quest.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		[HttpGet]
		public async Task<ActionResult<List<User>>> Get([FromServices] DataContext context)
		{
			var user = await context.Users.ToListAsync();
			return user;
		}

		[HttpPost]
		public async Task<ActionResult<User>> Post([FromServices] DataContext context,[FromBody] User model)
		{
			if(ModelState.IsValid)
			{
				context.Users.Add(model);
				await context.SaveChangesAsync();
				return model;
			}
			else
			{
				return BadRequest(ModelState);
			}
		}
	}
}