using Microsoft.EntityFrameworkCore;


namespace BusTickets.Data
{
    public class TicketDbContext : DbContext
    {
        public DbSet<Ticket> TicketSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=KAROLINA-LAPTOP;Database=TicketDatabase;Trusted_Connection=True;TrustServerCertificate=True;");

            // Update this with your actual connection string
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>().Property(t => t.TicketType).IsRequired();
            modelBuilder.Entity<Ticket>().Property(t => t.BuyerName).HasMaxLength(15);
            modelBuilder.Entity<Ticket>().Property(t => t.BuyerLastName).HasMaxLength(25);
        }

    }
}
