using BloggingPlatformLibrary.Interfaces;
using BloggingPlatformLibrary.Models;

namespace BloggingPlatformLibrary.Services
{
	public class ArticleService(IArticleRepository articleRepository, ICommentRepository commentRepository)
	{
		private readonly IArticleRepository _articleRepository = articleRepository;
		private readonly ICommentRepository _commentRepository = commentRepository;

		public async Task<IEnumerable<Article>> GetAllByAuthorId(int id)
		{
			return await _articleRepository.GetAllById(id);
		}

		public async Task<IEnumerable<Article>> GetAllByContent(string content)
		{
			return await _articleRepository.GetAllByContent(content);
		}

		public async Task<IDictionary<Article, float>> GetAllByRating()
		{
			Dictionary<Article, float> result = new();

			foreach (var article in await _articleRepository.GetAll())
			{
				float averageRating = 0f;

				foreach (var comment in await _commentRepository.GetAllByArticleId(article.Id))
				{
					averageRating += (float)comment.Rating;
				}

				result.Add(article, averageRating / _commentRepository.GetAllByArticleId(article.Id).Result.Count());
			}

			return result.OrderByDescending(r => r.Value).ToDictionary();
		}
	}
}
