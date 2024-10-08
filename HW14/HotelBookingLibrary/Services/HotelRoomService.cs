using HotelBookingLibrary.Interfaces;
using HotelBookingLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingLibrary.Services
{
	public class HotelRoomService(IRepository<HotelRoom> repository)
	{
		private readonly IRepository<HotelRoom> _repository = repository;

		public async Task AddHotelRoom(HotelRoom hotelRoom)
		{
			await _repository.Add(hotelRoom);
		}

		public async Task<HotelRoom> GetHotelRoomById(int id)
		{
			return await _repository.Get(id);
		}

		public async Task<IEnumerable<HotelRoom>> GetAllHotelRooms()
		{
			return await _repository.GetAll();
		}

		public async Task UpdateHotelRoom(HotelRoom hotelRoom)
		{
			await _repository.Update(hotelRoom);
		}

		public async Task DeleteHotelRoom(HotelRoom hotelRoom)
		{
			await _repository.Delete(hotelRoom);
		}
	}
}
