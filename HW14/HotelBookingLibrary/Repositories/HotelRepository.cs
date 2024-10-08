using HotelBookingLibrary.Data;
using HotelBookingLibrary.Interfaces;
using HotelBookingLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingLibrary.Repositories
{
	public class HotelRepository(HotelBookingDbContext context) : IRepository<Hotel>
	{
		private readonly HotelBookingDbContext _context = context;

		public async Task Add(Hotel entity)
		{
			_context.Hotels.Add(entity);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(Hotel entity)
		{
			_context.Hotels.Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<Hotel> Get(int id)
		{
			return await _context.Hotels.Where(h => h.Id == id).FirstAsync();
		}

		public async Task<IEnumerable<Hotel>> GetAll()
		{
			return await _context.Hotels.ToListAsync();
		}

		public Task<IEnumerable<Hotel>> GetAllById(int id)
		{
			throw new NotImplementedException();
		}

		public async Task Update(Hotel entity)
		{
			_context.Hotels.Update(entity);
			await _context.SaveChangesAsync();
		}
	}
}
