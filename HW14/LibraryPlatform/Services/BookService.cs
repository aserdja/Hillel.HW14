using LibraryPlatform.Interfaces;
using LibraryPlatform.Models;

namespace LibraryPlatform.Services
{
	public class BookService(IBookRepository bookRepository)
	{
		private readonly IBookRepository _bookRepository = bookRepository;

		public async Task<IEnumerable<Book>> SearchByTitle(string title)
		{
			return await _bookRepository.GetByTitle(title);
		}

		public async Task<IEnumerable<Book>> SearchByAuthor(string authorName)
		{
			return await _bookRepository.GetByAuthor(authorName);
		}

		public async Task<IEnumerable<Book>> SearchByTitleAndAuthor(string title, string authorName)
		{
			return await _bookRepository.GetByAuthorAndTitle(title, authorName);
		}
	}
}
