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


		private IUserRepository _repository;

		public UserController(IUserRepository repo)
		{
			_repository = repo;
		}

		[HttpGet]
		public async Task<IEnumerable<User>> Get()
		{
			return await _repository.GetUser();
		}

		[HttpPost]
		public async Task<ActionResult<User>> Post([FromServices] DataContext context,[FromBody] User model)
		{
			if(ModelState.IsValid)
			{
				return await _repository.NewUser(model);
			}
			else
			{
				return BadRequest(ModelState);
			}
		}
	}
}