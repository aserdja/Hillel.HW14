using BloggingPlatformLibrary.Data;
using BloggingPlatformLibrary.Interfaces;
using BloggingPlatformLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatformLibrary.Repositories
{
	public class ArticleRepository(BloggingPlatformDbContext _context) : IRepository<Article>
	{
		private readonly BloggingPlatformDbContext _context = _context;

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

		public async Task<Article> Get(int id)
		{
			return await _context.Articles.Where(a => a.Id == id).FirstAsync();
		}

		public async Task Update(Article entity)
		{
			_context.Update(entity);
			await _context.SaveChangesAsync();
		}
	}
}
