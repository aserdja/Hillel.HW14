using HotelBookingLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingLibrary.Data
{
	public class HotelBookingDbContext : DbContext
	{
		public virtual DbSet<Hotel> Hotels { get; set; }
		public virtual DbSet<HotelRoom> HotelRooms { get; set; }
		public virtual DbSet<RoomReservation> RoomsReservations { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HotelBooking;Integrated Security=True");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Hotel>().HasKey(h => h.Id);
			modelBuilder.Entity<HotelRoom>().HasKey(hr => hr.Id);
			modelBuilder.Entity<RoomReservation>().HasKey(rr => rr.Id);

			modelBuilder.Entity<Hotel>()
				.Property(h => h.Name)
				.IsRequired();

			modelBuilder.Entity<Hotel>()
				.Property(h => h.Address)
				.IsRequired();

			modelBuilder.Entity<Hotel>()
				.Property(h => h.StarRating)
				.IsRequired();

			modelBuilder.Entity<HotelRoom>()
				.Property(hr => hr.RoomName)
				.IsRequired();

			modelBuilder.Entity<HotelRoom>()
				.Property(hr => hr.Price)
				.IsRequired();

			modelBuilder.Entity<HotelRoom>()
				.Property(hr => hr.RoomClassification)
				.IsRequired();

			modelBuilder.Entity<RoomReservation>()
				.Property(rr => rr.StartDate)
				.IsRequired();

			modelBuilder.Entity<RoomReservation>()
				.Property(rr => rr.EndDate)
				.IsRequired();


			modelBuilder.Entity<Hotel>()
				.HasMany<HotelRoom>(h => h.HotelRooms)
				.WithOne(hr => hr.Hotel)
				.HasForeignKey(hr => hr.HotelId);
		}
	}
}
