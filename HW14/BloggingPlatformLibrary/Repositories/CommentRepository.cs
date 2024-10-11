using BloggingPlatformLibrary.Data;
using BloggingPlatformLibrary.Interfaces;
using BloggingPlatformLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatformLibrary.Repositories
{
	public class CommentRepository(BloggingPlatformDbContext context) : ICommentRepository
	{
		private readonly BloggingPlatformDbContext _context = context;

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

		public async Task<IEnumerable<Comment>> GetAll()
		{
			return await _context.Comments.ToListAsync();
		}

		public async Task<IEnumerable<Comment>> GetAllByArticleId(int articleId)
		{
			return await _context.Comments.Where(c => c.ArticleId == articleId).ToListAsync();
		}

		public async Task Update(Comment entity)
		{
			_context.Comments.Update(entity);
			await _context.SaveChangesAsync();
		}
	}
}
