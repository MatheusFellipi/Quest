using Quest.Entities;
using System;
using System.Threading.Tasks;

namespace Quest.UseCase
{
	public class PostCreateUseCase
	{
		private readonly IPostIRepository _repository;
		public PostCreateUseCase(IPostIRepository repo)
		{
			_repository = repo;
		}

		public async Task<dynamic> NewPost(Post post)
		{
			if (string.IsNullOrWhiteSpace(post.Description) || string.IsNullOrWhiteSpace(post.Title))
				throw new Exception("preencher o dados");

			return await _repository.NewPost(post);
		}

	}
}
