namespace Quest.Entities
{ 
	public class Post
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public bool Active { get; set; }
		public bool IsDelete { get; set; }
		public int Id_User { get; set; }
		public User User { get; set; }
	}
}
