namespace HotelBookingLibrary.Models
{
	public class Hotel
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public StarRating StarRating { get; set; }

		public ICollection<HotelRoom>? HotelRooms { get; set; }
	}
}
