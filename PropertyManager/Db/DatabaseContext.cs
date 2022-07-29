using System;
using Microsoft.EntityFrameworkCore;
using PropertyManager.Models;

namespace PropertyManager.Db
{
	public class DatabaseContext : DbContext
	{
		public DbSet<Property> Properties { get; set; }
		public DbSet<Resident> Residents { get; set; }
		public DbSet<Media> Mediae { get; set; }
		public DbSet<Ticket> Tickets { get; set; }
		public DbSet<TicketReply> TicketReplies { get; set; }
		public DbSet<Guest> Guests { get; set; }
		public DbSet<Alert> Alerts { get; set; }
		
		public DatabaseContext(DbContextOptions<DatabaseContext> options)
			: base(options)
		{
			this.Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			
		}
	}
}

