using Microsoft.EntityFrameworkCore;
using TicketSalesSystem.DAL.Entities;

namespace TicketSalesSystem.DAL.Data
{
	public class ApplicationContext : DbContext
	{
		public DbSet<Airplane> Airplane { get; set; }
		public DbSet<Flight> Flights { get; set; }
		public DbSet<FlightStatus> FlightsStatus { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Route> Routes { get; set; }
		public DbSet<SeatType> SeatTypes { get; set; }
		public DbSet<Ticket> Tickets { get; set; }
		public DbSet<Airline> Airlines { get; set; }
		public DbSet<Token> Tokens { get; set; }

		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>()
				.HasIndex(u => u.Email)
				.IsUnique();

			modelBuilder.Entity<Token>()
				.HasIndex(token => token.RefreshToken)
				.IsUnique();

			modelBuilder.Entity<Ticket>()
				.HasOne(t => t.SeatType)
				.WithMany(st => st.Tickets)
				.HasForeignKey(t => t.SeatTypeId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<SeatType>()
				.Property(s => s.Price)
				.HasColumnType("decimal(18,2)");

			modelBuilder.Entity<Ticket>()
				.Property(s => s.Price)
				.HasColumnType("decimal(18,2)");

			modelBuilder.Entity<Flight>()
				.Property(f => f.Price)
				.HasColumnType("decimal(18,2)");
		}

	}
}
