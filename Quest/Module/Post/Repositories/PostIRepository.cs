using Microsoft.EntityFrameworkCore;
using Quest.Data;
using Quest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quest.Repositories
{
	public class PostIRepository : IPostIRepository
	{

		private readonly DataContext _repositorio;
		public PostIRepository(DataContext repositorio)
		{
			_repositorio = repositorio;
		}
		public void DeletePost(int id)
		{
			_repositorio.Remove(id);
		}
		public async Task<Post> GetById(int id)
		{
			return await _repositorio.Posts.AsNoTracking()
				.Where(x => x.Id == id)
				.FirstOrDefaultAsync();
		}
		public async Task<List<Post>> GetByUser(int id)
		{
			return await _repositorio.Posts
				.AsNoTracking()
				.Where(x => x.Id_User == id)
				.Where(x => !x.IsDelete)
				.ToListAsync();
		}
		public async Task<IEnumerable<Post>> GetPost()
		{
			return await _repositorio.Posts.ToListAsync();
		}
		public async Task<Post> NewPost(Post post)
		{
			if (post.Id == 0)
			{
				_repositorio.Posts.Add(post);
				await _repositorio.SaveChangesAsync();
				return post;
			}
			else
			{
				return await UpdatePost(post);
			}
		}
		public async Task<Post> UpdatePost(Post post)
		{
			_repositorio.Posts.Update(post);
			await _repositorio.SaveChangesAsync();
			return post;
		}
	}
}
