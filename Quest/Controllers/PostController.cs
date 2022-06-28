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
	public class PostController : ControllerBase
	{
		[HttpGet]
		public async Task<ActionResult<List<Post>>> Get([FromServices] DataContext context)
		{
			var post = await context.Posts.Include(x=>x.User).ToListAsync();
			return post;
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<Post>> GetById([FromServices] DataContext context, int id)
		{
			var post = await context.Posts.Include(x => x.User)
				.AsNoTracking()
				.FirstOrDefaultAsync(x=>x.Id == id);
			return post;
		}

		[HttpGet]
		[Route("user/{id:int}")]
		public async Task<ActionResult<List<Post>>> GetByUser([FromServices] DataContext context, int id)
		{
			var post = await context.Posts
				.AsNoTracking()
				.Where(x => x.Id_User == id)
				.ToListAsync();

			return post;
		}

		[HttpPost]
		public async Task<ActionResult<Post>> Post([FromServices] DataContext context,[FromBody] Post model)
		{
			if(ModelState.IsValid)
			{
				context.Posts.Add(model);
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