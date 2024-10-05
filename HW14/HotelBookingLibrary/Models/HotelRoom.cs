namespace HotelBookingLibrary.Models
{
	public class HotelRoom
	{
		public int Id { get; set; }
		public string RoomName { get; set; } = null!;
		public RoomClassification RoomClassification { get; set; }
		public decimal Price { get; set; }

		public int HotelId { get; set; }
		public Hotel Hotel { get; set; } = null!;
	}
}