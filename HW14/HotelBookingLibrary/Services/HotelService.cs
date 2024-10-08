using HotelBookingLibrary.Interfaces;
using HotelBookingLibrary.Models;

namespace HotelBookingLibrary.Services
{
	public class HotelService(IRepository<Hotel> repository)
	{
		private readonly IRepository<Hotel> _repository = repository;

		public async Task AddHotel(Hotel hotel)
		{
			await _repository.Add(hotel);
		}

		public async Task<Hotel> GetHotelById(int id)
		{
			return await _repository.Get(id);
		}

		public async Task UpdateHotel(Hotel hotel)
		{
			await _repository.Update(hotel);
		}

		public async Task DeleteHotel(Hotel hotel)
		{
			await _repository.Delete(hotel);
		}
	}
}
