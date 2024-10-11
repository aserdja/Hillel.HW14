using BloggingPlatformLibrary.Data;
using BloggingPlatformLibrary.Interfaces;
using BloggingPlatformLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatformLibrary.Repositories
{
	public class AuthorRepository(BloggingPlatformDbContext context) : IAuthorRepository
	{
		private readonly BloggingPlatformDbContext _context = context;

		public async Task Add(Author entity)
		{
			_context.Authors.Add(entity);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(Author entity)
		{
			_context.Authors.Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Author>> GetAll()
		{
			return await _context.Authors.ToListAsync();
		}

		public async Task Update(Author entity)
		{
			_context.Authors.Update(entity);
			await _context.SaveChangesAsync();
		}
	}
}
