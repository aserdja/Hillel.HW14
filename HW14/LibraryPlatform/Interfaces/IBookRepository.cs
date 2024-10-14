using LibraryPlatform.Models;

namespace LibraryPlatform.Interfaces
{
	public interface IBookRepository : IRepository<Book>
	{
		Task<IEnumerable<Book>> GetByAuthorAndTitle(string authorName, string title);
		Task<IEnumerable<Book>> GetByTitle(string title);
		Task<IEnumerable<Book>> GetByAuthor(string authorName);
	}
}
