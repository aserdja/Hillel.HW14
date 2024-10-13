using LibraryPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryPlatform.Data
{
	public class LibraryPlatformDbContext : DbContext
	{
		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Book> Books { get; set; }
		public virtual DbSet<BookRental> BooksRentals { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
				.Property(u => u.Name)
				.IsRequired();

			modelBuilder.Entity<Book>()
				.Property(b => b.Title)
				.IsRequired();

			modelBuilder.Entity<Book>()
				.Property(b => b.Author)
				.IsRequired();

			modelBuilder.Entity<Book>()
				.Property(b => b.ISBN)
				.IsRequired();

			modelBuilder.Entity<BookRental>()
				.Property(br => br.StartRentalDateTime)
				.IsRequired();

			modelBuilder.Entity<BookRental>()
				.Property(br => br.EndRentalDateTime)
				.IsRequired();


			modelBuilder.Entity<User>()
				.HasMany<BookRental>(u => u.Rentals)
				.WithOne(br => br.User)
				.HasForeignKey(br => br.UserId);

			modelBuilder.Entity<Book>()
				.HasMany<BookRental>(b => b.Rentals)
				.WithOne(br => br.Book)
				.HasForeignKey(br => br.BookId);
		}
	}
}
