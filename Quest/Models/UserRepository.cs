

using System.Collections.Generic;

namespace Quest.Models
{
	interface UserRepository
	{
		List<User> User { get; }
		User this[int id] { get; }
		User NewUser(User user);
		User UpdateUser(User user);
		void DeleteUser(int id);

	}
}
