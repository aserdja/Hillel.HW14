using HotelBookingLibrary.Data;
using HotelBookingLibrary.Interfaces;
using HotelBookingLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingLibrary.Repositories
{
	public class HotelRoomRepository(HotelBookingDbContext context) : IHotelRoomRepository
	{
		private readonly HotelBookingDbContext _context = context;

		public async Task Add(HotelRoom entity)
		{
			_context.HotelRooms.Add(entity);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(HotelRoom entity)
		{
			_context.HotelRooms.Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<HotelRoom>> GetAll()
		{
			return await _context.HotelRooms.ToListAsync();
		}

		public async Task Update(HotelRoom entity)
		{
			_context.HotelRooms.Update(entity);
			await _context.SaveChangesAsync();
		}
	}
}
