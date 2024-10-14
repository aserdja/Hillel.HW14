using LibraryPlatform.Models;

namespace LibraryPlatform.Interfaces
{
	public interface IBookRentalRepository : IRepository<BookRental>
	{
		public Task<IEnumerable<BookRental>> GetAllByBook(Book book);
	}
}
