namespace BloggingPlatformLibrary.Models
{
	public class Author
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;

		public ICollection<Article>? Articles { get; set; }
	}
}
