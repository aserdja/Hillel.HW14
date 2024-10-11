using HotelBookingLibrary.Interfaces;

namespace HotelBookingLibrary.Services
{
	public class RoomReservationService(IRoomReservationRepository repository)
	{
		private readonly IRoomReservationRepository _roomReservationRepository = repository;

		public async Task CancelReservation(int roomId, DateTime startDateTime)
		{
			var reservationToDelete = await _roomReservationRepository.GetByRoomIdAndStartDate(roomId, startDateTime);
			await _roomReservationRepository.Delete(reservationToDelete);
		}
	}
}
