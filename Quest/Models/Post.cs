﻿using System.ComponentModel.DataAnnotations;


namespace Quest.Models
{
	public class Post
	{
		[Key]
		public int Id { get; set; }

		public string Title { get; set; }
		public string Description { get; set; }
		public bool Active { get; set; }
		public int Id_User { get; set; }
		public User User { get; set; }
	}
}