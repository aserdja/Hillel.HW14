using BloggingPlatformLibrary.Interfaces;
using BloggingPlatformLibrary.Models;

namespace BloggingPlatformLibrary.Services
{
	public class AuthorService(IRepository<Author> repository)
	{
		private readonly IRepository<Author> _repository = repository;

		public async Task AddAuthor(Author author)
		{
			await _repository.Add(author);
		}

		public async Task RemoveAuthor(Author author)
		{
			await _repository.Delete(author);
		}

		public async Task UpdateAuthor(Author author)
		{
			await _repository.Update(author);
		}

		public async Task<Author> GetAuthorById(int id)
		{
			return await _repository.Get(id);
		}
	}
}
