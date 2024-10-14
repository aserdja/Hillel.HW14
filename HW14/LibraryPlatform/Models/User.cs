namespace LibraryPlatform.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;

		public ICollection<BookRental>? Rentals { get; set; }
	}
}
