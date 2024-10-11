using BloggingPlatformLibrary.Models;

namespace BloggingPlatformLibrary.Interfaces
{
	public interface IArticleRepository : IRepository<Article>
	{
		Task<IEnumerable<Article>> GetAllById(int id);
		Task<IEnumerable<Article>> GetAllByContent(string content);
	}
}
