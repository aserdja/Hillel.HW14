namespace BloggingPlatformLibrary.Models
{
	public class Comment
	{
		public int Id { get; set; }
		public string UserName { get; set; } = null!;
		public string Content { get; set; } = null!;
		public DateTime WritingDateTime { get; set; }
		public Rating Rating { get; set; }

		public int ArticleId { get; set; }
		public Article Article { get; set; } = null!;


		public Comment(string userName, string content, Rating rating, Article article)
		{
			UserName = userName;
			Content = content;
			WritingDateTime = DateTime.Now;
			Rating = rating;
			Article = article;
		}
	}
}