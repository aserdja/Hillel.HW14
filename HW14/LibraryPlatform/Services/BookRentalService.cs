using LibraryPlatform.Interfaces;
using LibraryPlatform.Models;

namespace LibraryPlatform.Services
{
	public class BookRentalService(IBookRepository bookRepository, IBookRentalRepository bookRentalRepository)
	{
		private readonly IBookRepository _bookRepository = bookRepository;
		private readonly IBookRentalRepository _bookRentalRepository = bookRentalRepository;

		public async Task RentBook(User user, Book book, DateTime startRentDate, DateTime endRentDate)
		{
			if (await CheckBookAvailability(book, startRentDate, endRentDate))
			{
				await _bookRentalRepository.Add(new BookRental()
				{
					Book = book,
					User = user,
					StartRentalDateTime = startRentDate,
					EndRentalDateTime = endRentDate
				});
			}
		}

		public async Task<bool> CheckBookAvailability(Book book, DateTime startDateTime, DateTime endDateTime)
		{
			bool isAvailable = true;

			foreach (var rental in await _bookRentalRepository.GetAllByBook(book))
			{
				if ((rental.StartRentalDateTime <= startDateTime && rental.EndRentalDateTime <= endDateTime && rental.EndRentalDateTime >= startDateTime) ||
					(rental.StartRentalDateTime <= startDateTime && rental.EndRentalDateTime >= endDateTime) ||
					(rental.StartRentalDateTime >= startDateTime && rental.EndRentalDateTime <= endDateTime) ||
					(rental.StartRentalDateTime >= startDateTime && rental.EndRentalDateTime >= endDateTime && rental.StartRentalDateTime < endDateTime))
				{
					isAvailable = false;
				}
			}

			return isAvailable;
		}
	}
}
