
using Quest.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quest
{
	public interface IPostIRepository
	{
		Task<IEnumerable<Post>> GetPost();
		Task<List<Post>> GetByUser(int id);
		Task<Post> GetById(int id);
		Task<Post> NewPost(Post user);
		Task<Post> UpdatePost(Post user);
		void DeletePost(int id);
	}
}
