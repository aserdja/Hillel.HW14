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
			optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BloggingPlatform;Integrated Security=True");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Hotel>()
				.Property(h => h.Name)
				.IsRequired();

			modelBuilder.Entity<Hotel>()
				.Property(h => h.StarRating)
				.IsRequired();

			modelBuilder.Entity<HotelRoom>()
				.Property(hr => hr.Name)
				.IsRequired();

			modelBuilder.Entity<HotelRoom>()
				.Property(hr => hr.Price)
				.IsRequired();

			modelBuilder.Entity<HotelRoom>()
				.Property(hr => hr.RoomType)
				.IsRequired();

			modelBuilder.Entity<RoomReservation>()
				.Property(rr => rr.StartDateTime)
				.IsRequired();

			modelBuilder.Entity<RoomReservation>()
				.Property(rr => rr.EndDateTime)
				.IsRequired();


			modelBuilder.Entity<Hotel>()
				.HasMany<HotelRoom>(h => h.HotelRooms)
				.WithOne(hr => hr.Hotel)
				.HasForeignKey(hr => hr.HotelId);

			modelBuilder.Entity<HotelRoom>()
				.HasMany<RoomReservation>(hr => hr.RoomReservations)
				.WithOne(rr => rr.HotelRoom)
				.HasForeignKey(rr => rr.HotelRoomId);
		}
	}
}
