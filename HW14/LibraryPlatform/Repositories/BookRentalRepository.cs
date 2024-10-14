using LibraryPlatform.Data;
using LibraryPlatform.Interfaces;
using LibraryPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryPlatform.Repositories
{
	public class BookRentalRepository(LibraryPlatformDbContext context) : IBookRentalRepository
	{
		private readonly LibraryPlatformDbContext _context = context;

		public async Task Add(BookRental entity)
		{
			_context.BooksRentals.Add(entity);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(BookRental entity)
		{
			_context.BooksRentals.Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<BookRental>> GetAll()
		{
			return await _context.BooksRentals.ToListAsync();
		}

		public async Task<IEnumerable<BookRental>> GetAllByBook(Book book)
		{
			return await _context.BooksRentals.Where(br => br.Book ==  book).ToListAsync();
		}

		public async Task Update(BookRental entity)
		{
			_context.BooksRentals.Update(entity);
			await _context.SaveChangesAsync();
		}
	}
}
