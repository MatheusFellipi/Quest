using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quest.Data;
using Quest.Entities;
using Quest.UseCase;
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

		private readonly PostCreateUseCase _postCreateUseCase;
		private readonly PostListUseCase _listUseCase;

		public PostController(IPostIRepository repo)
		{
			_postCreateUseCase = new PostCreateUseCase(repo);
			_listUseCase = new PostListUseCase(repo);
		}

		[HttpGet]
		public async Task<IEnumerable<Post>> Get()
		{
			return await _listUseCase.Get();
		}

		[HttpGet]
		[Route("user/{id:int}")]
		[Authorize]
		public async Task<IEnumerable<Post>> GetByUser(int id)
		{
			return await _listUseCase.GetByUser(id);
		}

		[HttpPost]
		[Authorize]
		public async Task<ActionResult<Post>> Post([FromBody] Post model)
		{
			try
			{
				return await _postCreateUseCase.NewPost(model); 
			}
			catch (Exception e)
			{
				return StatusCode(400, e.Message);
			}
		}
	}
}