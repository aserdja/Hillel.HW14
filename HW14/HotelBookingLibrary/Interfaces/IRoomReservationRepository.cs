using HotelBookingLibrary.Models;

namespace HotelBookingLibrary.Interfaces
{
	public interface IRoomReservationRepository : IRepository<RoomReservation>
	{
		Task<IEnumerable<RoomReservation>> GetAllByRoomId(int roomId);
		Task<RoomReservation> GetByRoomIdAndStartDate(int roomId, DateTime startDate);
	}
}
