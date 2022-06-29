using Quest.Entities;
using Quest.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quest.UseCase
{
	public class ListUserUseCase
	{
		private readonly IUserRepository _repository;
		public ListUserUseCase(IUserRepository repo)
		{
			_repository = repo;
		}

		public async Task<User> GetByEmail(string email)
		{
			return await _repository.GetByEmail(email);
		}
	}
}
