using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quest.Data;
using Quest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quest.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PostController : ControllerBase
	{

		private readonly IPostIRepository _repository;

		public PostController(IPostIRepository repo)
		{
			_repository = repo;
		}

		[HttpGet]
		public async Task<IEnumerable<Post>> Get()
		{
			return await _repository.GetPost();
		}

		[HttpGet]
		[Route("user/{id:int}")]
		public async Task<List<Post>> GetByUser(int id)
		{
			return await _repository.GetByUser(id);
		}

		[HttpPost]
		public async Task<ActionResult<Post>> Post([FromBody] Post model)
		{
			if(ModelState.IsValid)
			{
				await _repository.NewPost(model);
				return model;
			}
			else
			{
				return BadRequest(ModelState);
			}
		}
	}
}