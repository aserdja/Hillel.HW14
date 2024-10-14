using LibraryPlatform.Data;
using LibraryPlatform.Interfaces;
using LibraryPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryPlatform.Repositories
{
	public class UserRepository(LibraryPlatformDbContext context) : IUserRepository
	{
		private readonly LibraryPlatformDbContext _context = context;

		public async Task Add(User entity)
		{
			_context.Users.Add(entity);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(User entity)
		{
			_context.Users.Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<User>> GetAll()
		{
			return await _context.Users.ToListAsync();
		}

		public async Task Update(User entity)
		{
			_context.Users.Update(entity);
			await _context.SaveChangesAsync();
		}
	}
}
