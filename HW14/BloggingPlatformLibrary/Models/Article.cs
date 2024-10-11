namespace BloggingPlatformLibrary.Models
{
	public class Article
	{
		public int Id { get; set; }
		public string Title { get; set; } = null!;
		public string Content { get; set; } = null!;

		public int AuthorId { get; set; }
		public Author Author { get; set; } = null!;

		public ICollection<Comment>? Comments { get; set; }
	}
}