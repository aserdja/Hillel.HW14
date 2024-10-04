using BloggingPlatformLibrary.Interfaces;
using BloggingPlatformLibrary.Models;

namespace BloggingPlatformLibrary.Services
{
	public class ArticleService(IRepository<Article> repository)
	{
		private readonly IRepository<Article> _repository = repository;

		public async Task AddArticle(Article article)
		{
			await _repository.Add(article);
		}

		public async Task RemoveArticle(Article article)
		{
			await _repository.Delete(article);
		}

		public async Task UpdateArticle(Article article)
		{
			await _repository.Update(article);
		}

		public async Task<Article> GetArticleById(int id)
		{
			return await _repository.Get(id);
		}
	}
}
