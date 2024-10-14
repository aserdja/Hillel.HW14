namespace LibraryPlatform.Models
{
	public class BookRental
	{
		public int Id { get; set; }
		public DateTime StartRentalDateTime { get; set; }
		public DateTime EndRentalDateTime { get; set; }

		public int UserId { get; set; }
		public User User { get; set; } = null!;

		public int BookId { get; set; }
		public Book Book { get; set; } = null!;
	}
}
