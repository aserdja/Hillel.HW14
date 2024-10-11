using HotelBookingLibrary.Data;
using HotelBookingLibrary.Interfaces;
using HotelBookingLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingLibrary.Repositories
{
	public class HotelRepository(HotelBookingDbContext context) : IHotelRepository
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

		public async Task<IEnumerable<Hotel>> GetAll()
		{
			return await _context.Hotels.ToListAsync();
		}

		public async Task Update(Hotel entity)
		{
			_context.Hotels.Update(entity);
			await _context.SaveChangesAsync();
		}
	}
}
