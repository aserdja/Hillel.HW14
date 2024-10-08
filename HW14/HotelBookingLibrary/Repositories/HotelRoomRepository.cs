using HotelBookingLibrary.Data;
using HotelBookingLibrary.Interfaces;
using HotelBookingLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingLibrary.Repositories
{
	public class HotelRoomRepository(HotelBookingDbContext context) : IRepository<HotelRoom>
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

		public async Task<HotelRoom> Get(int id)
		{
			return await _context.HotelRooms.Where(hr => hr.Id == id).FirstAsync();
		}

		public async Task<IEnumerable<HotelRoom>> GetAll()
		{
			return await _context.HotelRooms.ToListAsync();
		}

		public Task<IEnumerable<HotelRoom>> GetAllById(int id)
		{
			throw new NotImplementedException();
		}

		public async Task Update(HotelRoom entity)
		{
			_context.HotelRooms.Update(entity);
			await _context.SaveChangesAsync();
		}
	}
}
