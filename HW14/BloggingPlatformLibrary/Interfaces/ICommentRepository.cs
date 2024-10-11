using BloggingPlatformLibrary.Models;

namespace BloggingPlatformLibrary.Interfaces
{
	public interface ICommentRepository : IRepository<Comment>
	{
		Task<IEnumerable<Comment>> GetAllByArticleId(int articleId);
	}
}
