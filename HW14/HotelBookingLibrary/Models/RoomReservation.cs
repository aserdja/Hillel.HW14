namespace HotelBookingLibrary.Models
{
	public class RoomReservation
	{
		public int Id { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }

		public int HotelRoomId { get; set; }
		public HotelRoom HotelRoom { get; set; } = null!;
	}
}
