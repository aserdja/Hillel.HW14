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

		public async Task<IEnumerable<Book>> GetByAuthor(string authorName)
		{
			return await _context.Books.Where(b => b.Author.Contains(authorName)).ToListAsync();
		}

		public async Task<IEnumerable<Book>> GetByTitle(string title)
		{
			return await _context.Books.Where(b => b.Title.Contains(title)).ToListAsync();
		}

		public async Task<IEnumerable<Book>> GetByAuthorAndTitle(string authorName, string title)
		{
			return await _context.Books.Where(b => b.Author.Contains(authorName) && b.Title.Contains(title)).ToListAsync();
		}

		public async Task Update(Book entity)
		{
			_context.Books.Update(entity);
			await _context.SaveChangesAsync();
		}
	}
}
