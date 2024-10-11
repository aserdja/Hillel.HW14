using BloggingPlatformLibrary.Data;
using BloggingPlatformLibrary.Interfaces;
using BloggingPlatformLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatformLibrary.Repositories
{
	public class ArticleRepository(BloggingPlatformDbContext context) : IArticleRepository
	{
		private readonly BloggingPlatformDbContext _context = context;

		public async Task Add(Article entity)
		{
			_context.Articles.Add(entity);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(Article entity)
		{
			_context.Articles.Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Article>> GetAll()
		{
			return await _context.Articles.ToListAsync();
		}

		public async Task<IEnumerable<Article>> GetAllByContent(string content)
		{
			return await _context.Articles.Where(ar => ar.Content.Contains(content)).ToListAsync();
		}

		public async Task<IEnumerable<Article>> GetAllById(int id)
		{
			return await _context.Articles.Where(ar => ar.AuthorId == id).ToListAsync();
		}

		public async Task Update(Article entity)
		{
			_context.Articles.Update(entity);
			await _context.SaveChangesAsync();
		}
	}
}
