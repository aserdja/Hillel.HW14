using BloggingPlatformLibrary.Data;
using BloggingPlatformLibrary.Interfaces;
using BloggingPlatformLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatformLibrary.Repositories
{
	public class AuthorRepository(BloggingPlatformDbContext _context) : IRepository<Author>
	{
		private readonly BloggingPlatformDbContext _context = _context;

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

		public async Task<Author> Get(int id)
		{
			return await _context.Authors.Where(a => a.Id == id).FirstAsync();
		}

		public async Task<IEnumerable<Author>> GetAll()
		{
			return await _context.Authors.ToListAsync();
		}

		public Task<IEnumerable<Author>> GetAllById(int id)
		{
			throw new NotImplementedException();
		}

		public async Task Update(Author entity)
		{
			_context.Update(entity);
			await _context.SaveChangesAsync();
		}
	}
}
