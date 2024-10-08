using HotelBookingLibrary.Interfaces;
using HotelBookingLibrary.Models;

namespace HotelBookingLibrary.Services
{
	public class HotelRoomsFilter(IRepository<HotelRoom> roomsRepository, IRepository<RoomReservation> reservationsRepository)
	{
		private readonly IRepository<HotelRoom> _roomRepository = roomsRepository;
		private readonly IRepository<RoomReservation> _reservationsRepository = reservationsRepository;

		public async Task<IEnumerable<HotelRoom>> GetAllFreeRooms()
		{
			var freeRooms = new List<HotelRoom>();

			foreach (var room in await _roomRepository.GetAll())
			{
				if (_reservationsRepository.GetAllById(room.Id).Result.Count() == 0)
				{
					freeRooms.Add(room);
				}

				foreach (var reservation in await _reservationsRepository.GetAllById(room.Id))
				{
					if (reservation.StartDate < DateTime.Now && reservation.EndDate > DateTime.Now)
					{
						continue;
					}
					freeRooms.Add(room);
				}
			}
			return freeRooms;
		}

		public async Task<IEnumerable<HotelRoom>> GetAllFreeRoomsByDate(DateTime startDate, DateTime endDate)
		{
			var freeRooms = new List<HotelRoom>();

			foreach (var room in await _roomRepository.GetAll())
			{
				if (_reservationsRepository.GetAllById(room.Id).Result.Count() == 0)
				{
					freeRooms.Add(room);
				}
				foreach (var reservation in await _reservationsRepository.GetAllById(room.Id))
				{
					bool isAvailable = false;
					if (reservation.EndDate < startDate | reservation.StartDate > endDate)
					{
						isAvailable = true;
					}
					else
					{
						isAvailable = false;
						break;
					}

					if (isAvailable)
					{
						freeRooms.Add(room);
					}
				}
			}

			return freeRooms;
		}
	}
}
