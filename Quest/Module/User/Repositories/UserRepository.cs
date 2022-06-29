using Microsoft.EntityFrameworkCore;
using Quest.Data;
using Quest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quest.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly DataContext _repositorio;
		public UserRepository(DataContext repositorio)
		{
			_repositorio = repositorio;
		}

		public async Task<User> GetById(int id) => await _repositorio.Users.FindAsync(id);

		public async Task<User> GetByEmail(string email) => await _repositorio.Users.AsNoTracking()
				.Where(x => x.Email == email).FirstOrDefaultAsync();
		public async Task<IEnumerable<User>> GetUser()
		{
			return await _repositorio.Users.ToListAsync();
		}

		public void DeleteUser(int id)
		{
			_repositorio.Remove(id);
		}

		public async Task<User> NewUser(User user)
		{
			if (user.Id == 0)
			{
				_repositorio.Users.Add(user);
				await _repositorio.SaveChangesAsync();
				return user;
			}

			return user;
		}

		public User UpdateUser(User user)
		{
			throw new NotImplementedException();
		}
	}
}
