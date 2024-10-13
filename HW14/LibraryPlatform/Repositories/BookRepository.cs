using LibraryPlatform.Data;
using LibraryPlatform.Interfaces;
using LibraryPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryPlatform.Repositories
{
	public class BookRepository(LibraryPlatformDbContext context) : IBookRepository
	{
		private readonly LibraryPlatformDbContext _context = context;

		public async Task Add(Book entity)
		{
			_context.Books.Add(entity);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(Book entity)
		{
			_context.Books.Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Book>> GetAll()
		{
			return await _context.Books.ToListAsync();
		}

		public async Task Update(Book entity)
		{
			_context.Books.Update(entity);
			await _context.SaveChangesAsync();
		}
	}
}
