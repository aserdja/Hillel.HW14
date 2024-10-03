using BloggingPlatformLibrary.Data;
using BloggingPlatformLibrary.Interfaces;
using BloggingPlatformLibrary.Models;

namespace BloggingPlatformLibrary.Repositories
{
	public class AuthorRepository(BloggingPlatformDbContext _context) : IRepository<Author>
	{
		private readonly BloggingPlatformDbContext _context = _context;

		public void Add(Author entity)
		{
			_context.Authors.Add(entity);
			_context.SaveChanges();
		}

		public void Delete(Author entity)
		{
			_context.Authors.Remove(entity);
			_context.SaveChanges();
		}

		public Author Get(int id)
		{
			return _context.Authors.Where(a => a.Id == id).First();
		}

		public void Update(Author entity)
		{
			_context.Update(entity);
			_context.SaveChanges();
		}
	}
}
