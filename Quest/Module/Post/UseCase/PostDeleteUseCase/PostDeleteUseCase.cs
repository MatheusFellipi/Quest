using Quest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quest.UseCase
{
	public class PostDeleteUseCase
	{
		private readonly IPostIRepository _repository;
		public PostDeleteUseCase(IPostIRepository repo)
		{
			_repository = repo;
		}

		public async Task<dynamic> Delete(int id)
		{
			var post = await _repository.GetById(id);

			if (post != null)
			{
				post.IsDelete = true;
			}

			return await _repository.GetPost();
		}
	}
}
