using System.Collections.Generic;
using System.Threading.Tasks;

using Quest.Entities;

namespace Quest.Repositories
{
	public interface IUserRepository 
	{
		Task<IEnumerable<User>> GetUser();
		Task<User> GetById(int id);
		Task<User> GetByEmail(string id);
		Task<User> NewUser(User user);
		User UpdateUser(User user);
		void DeleteUser(int id);

	}
}
