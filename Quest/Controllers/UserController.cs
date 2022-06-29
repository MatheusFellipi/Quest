using Microsoft.AspNetCore.Mvc;
using Quest.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

using Quest.Entities;
using Quest.Repositories;

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