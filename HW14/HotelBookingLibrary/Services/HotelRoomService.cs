using HotelBookingLibrary.Interfaces;
using HotelBookingLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingLibrary.Services
{
	public class HotelRoomService(IHotelRoomRepository roomRepository, IRoomReservationRepository roomReservationRepository)
	{
		private readonly IHotelRoomRepository _roomRepository = roomRepository;
		private readonly IRoomReservationRepository _roomReservationRepository = roomReservationRepository;

		public async Task<IEnumerable<HotelRoom>> GetAllFreeRooms()
		{
			List<HotelRoom> availableHotelRoomsList = new List<HotelRoom>();

			foreach (var hotelRoom in await _roomRepository.GetAll())
			{
				bool isAvailableForNow = true;

				foreach (var reservation in await _roomReservationRepository.GetAllByRoomId(hotelRoom.Id))
				{
					if (reservation.StartDateTime < DateTime.Now && reservation.EndDateTime > DateTime.Now)
					{
						isAvailableForNow = false;
					}
				}

				if (isAvailableForNow)
				{
					availableHotelRoomsList.Add(hotelRoom);
				}
			}

			return availableHotelRoomsList;
		}

		public async Task<IEnumerable<HotelRoom>> GetAllFreeRoomsByDate(DateTime startDateTime, DateTime endDateTime)
		{
			List<HotelRoom> availableHotelRoomsList = new List<HotelRoom>();

			foreach (var hotelRoom in await _roomRepository.GetAll())
			{
				bool isAvailableForNow = true;

				foreach (var reservation in await _roomReservationRepository.GetAllByRoomId(hotelRoom.Id))
				{
					if ((reservation.StartDateTime < startDateTime && reservation.EndDateTime < endDateTime && reservation.EndDateTime > startDateTime) | 
						(reservation.StartDateTime < startDateTime && reservation.EndDateTime > endDateTime) |
						(reservation.StartDateTime > startDateTime && reservation.EndDateTime < endDateTime) |
						(reservation.StartDateTime > startDateTime && reservation.EndDateTime > endDateTime && reservation.StartDateTime < endDateTime))
					{
						isAvailableForNow = false;
					}
				}

				if (isAvailableForNow)
				{
					availableHotelRoomsList.Add(hotelRoom);
				}
			}

			return availableHotelRoomsList;
		}
	}
}
