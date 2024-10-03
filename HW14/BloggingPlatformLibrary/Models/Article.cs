namespace BloggingPlatformLibrary.Models
{
	public class Article
	{
		public int Id { get; set; }
		public string Title { get; set; } = null!;
		public string Content { get; set; } = null!;
		public DateOnly PublicationDate { get; set; }

		public int AuthorId { get; set; }
		public Author Author { get; set; } = null!;

		public ICollection<Comment>? Comments { get; set; }


		public Article(string title, string content, Author authorOfArticle)
		{
			Title = title;
			Content = content;
			PublicationDate = DateOnly.Parse(DateTime.Now.Date.ToString());
		}
	}
}