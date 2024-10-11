namespace HotelBookingLibrary.Models
{
	public class HotelRoom
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public decimal Price { get; set; }
		public RoomType RoomType { get; set; }

		public int HotelId { get; set; }
		public Hotel Hotel { get; set; } = null!;

		public ICollection<RoomReservation>? RoomReservations { get; set; }
	}
}