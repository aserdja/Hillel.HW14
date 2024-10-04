using BloggingPlatformLibrary.Data;
using BloggingPlatformLibrary.Interfaces;
using BloggingPlatformLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatformLibrary.Repositories
{
	public class CommentRepository(BloggingPlatformDbContext _context) : IRepository<Comment>
	{
		private readonly BloggingPlatformDbContext _context = _context;

		public async Task Add(Comment entity)
		{
			_context.Comments.Add(entity);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(Comment entity)
		{
			_context.Comments.Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<Comment> Get(int id)
		{
			return await _context.Comments.Where(a => a.Id == id).FirstAsync();
		}

		public async Task<IEnumerable<Comment>> GetAll()
		{
			return await _context.Comments.ToListAsync();
		}

		public async Task<IEnumerable<Comment>> GetAllById(int id)
		{
			return await _context.Comments.Where(c => c.ArticleId == id).ToListAsync();
		}

		public async Task Update(Comment entity)
		{
			_context.Update(entity);
			await _context.SaveChangesAsync();
		}
	}
}
