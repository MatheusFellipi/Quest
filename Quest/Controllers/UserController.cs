using Microsoft.AspNetCore.Mvc;
using Quest.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

using Quest.Entities;
using Quest.Repositories;
using Quest.UseCase;
using System;

namespace Quest.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly CreateUseCase _createUseCase;

		public UserController(IUserRepository repo)
		{
			_createUseCase = new CreateUseCase(repo);
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<User>>> Get()
		{
			return Ok(await _createUseCase.GetUser());
		}

		[HttpPost]
		public async Task<ActionResult<dynamic>> Post([FromBody] User model)
		{
			try
			{
				return Ok(await _createUseCase.NewUser(model));
			}
			catch (Exception e)
			{
				return StatusCode(400, e.Message);
			}
		}
	}
}