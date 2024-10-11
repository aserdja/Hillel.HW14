namespace HotelBookingLibrary.Models
{
	public class RoomReservation
	{
		public int Id { get; set; }
		public DateTime StartDateTime { get; set; }
		public DateTime EndDateTime { get; set; }

		public int HotelRoomId { get; set; }
		public HotelRoom HotelRoom { get; set; } = null!;
	}
}