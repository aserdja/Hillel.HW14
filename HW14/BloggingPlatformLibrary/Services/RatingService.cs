using BloggingPlatformLibrary.Interfaces;
using BloggingPlatformLibrary.Models;
using BloggingPlatformLibrary.Repositories;
using System.Runtime.CompilerServices;

namespace BloggingPlatformLibrary.Services
{
	public class RatingService(IRepository<Article> articleRepository, IRepository<Comment> commentRepository)
	{
		private readonly IRepository<Article> _articleRepository = articleRepository;
		private readonly IRepository<Comment> _commentRepository = commentRepository;

		public async Task<IDictionary<Article, double>> GetAllArticlesByRating()
		{
			var ratingDictionary = new Dictionary<Article, double>();
			var listOfArticles = _articleRepository.GetAll();
			
            foreach (var article in listOfArticles.Result)
            {

				var listOfComments = await _commentRepository.GetAllById(article.Id);
				var sum = 0.0;

				if (listOfComments.Count() != 0)
				{
					foreach (var comment in listOfComments)
					{
						sum += (byte)comment.Rating;
					}

					var rating = sum / listOfComments.Count();
					ratingDictionary.Add(article, rating);
				}
            }
			return ratingDictionary;
		}
	}
}
