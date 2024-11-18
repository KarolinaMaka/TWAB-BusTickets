using Microsoft.EntityFrameworkCore;

namespace BusTickets.Data
{
    public class TicketDbContext : DbContext
    {
        public TicketDbContext(DbContextOptions<TicketDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ticket> TicketSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-5OBBIUS;Database=TicketDatabase;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>().Property(t => t.TicketType).IsRequired();
            modelBuilder.Entity<Ticket>().Property(t => t.BuyerName).HasMaxLength(15);
            modelBuilder.Entity<Ticket>().Property(t => t.BuyerLastName).HasMaxLength(25);
        }
    }
}
