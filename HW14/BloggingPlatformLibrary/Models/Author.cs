namespace BloggingPlatformLibrary.Models
{
	public class Author
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string? Description { get; set; }
		public ICollection<Article>? Articles { get; set; }


		public Author(string name, string description = "")
		{
			Name = name;
			Description = description;
		}
	}
}
