using Microsoft.EntityFrameworkCore;
using Quest.Entities;

namespace Quest.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> opt) : base(opt) {
			this.Database.EnsureCreated();
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Post> Posts { get; set; }

	}
}
