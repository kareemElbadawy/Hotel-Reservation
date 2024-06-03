using Reservation.Domain;
using Reservation.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Reservation.Core.EFContext
{
	public class DatabaseContext : IdentityDbContext<ApplicationUser>, IDatabaseContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{
		}

		public DbSet<City> City { get; set; }
		public DbSet<Hotel> Hotel { get; set; }
		public DbSet<HotelUser> HotelUser { get; set; }
		public DbSet<Reservations> Reservations { get; set; }
		public DbSet<ReservationStatus> ReservationStatus { get; set; }
		public DbSet<Room> Room { get; set; }
		public DbSet<User> User { get; set; }
		public DbSet<UserRole> UserRole { get; set; }
		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

		}
	}
}
