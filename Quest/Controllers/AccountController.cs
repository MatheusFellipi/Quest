using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quest.Data;
using Quest.Entities;
using Quest.Repositories;
using Quest.Services;

namespace Quest.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IUserRepository _repository;
		public AccountController(IUserRepository repo)
		{
			_repository = repo;
		}

		[HttpPost]
		[Route("login")]
		[AllowAnonymous]
		public async Task<dynamic> Autheticate([FromBody] User model)
		{

			var user = await _repository.GetByEmail(model.Email);

			if (user == null)
				return NotFound(new { message = "Usuario ou senha invalido" });

			if (user.Password != HashValue.GenerateHash(model.Password))
				return NotFound(new { message = "Usuario ou senha invalido" });

			var token = TokenServices.GenerateToken(user);
			user.Password = "";
			return new
			{
				user = user,
				token = token
			};
		}
	}
}
