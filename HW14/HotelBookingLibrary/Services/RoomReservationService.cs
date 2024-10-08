using HotelBookingLibrary.Interfaces;
using HotelBookingLibrary.Models;

namespace HotelBookingLibrary.Services
{
	public class RoomReservationService(IRepository<RoomReservation> repository)
	{
		private readonly IRepository<RoomReservation> _repository = repository;

		public async Task AddRoomReservation(RoomReservation roomReservation)
		{
			await _repository.Add(roomReservation);
		}

		public async Task<RoomReservation> GetRoomReservationById(int id)
		{
			return await _repository.Get(id);
		}

		public async Task<IEnumerable<RoomReservation>> GetAllRoomReservations()
		{
			return await _repository.GetAll();
		}

		public async Task UpdateRoomReservation(RoomReservation roomReservation)
		{
			await _repository.Update(roomReservation);
		}

		public async Task DeleteRoomReservation(RoomReservation roomReservation)
		{
			await _repository.Delete(roomReservation);
		}

		
	}
}
