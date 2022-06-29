using Quest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quest.UseCase
{
	public class ListUseCase
	{
		private readonly IPostIRepository _repository;
		public ListUseCase(IPostIRepository repo)
		{
			_repository = repo;
		}

		public async Task<IEnumerable<Post>> Get()
		{
			return await _repository.GetPost();
		}

		public async Task<IEnumerable<Post>> GetByUser(int id)
		{
			return await _repository.GetByUser(id);
		}
	}
}
