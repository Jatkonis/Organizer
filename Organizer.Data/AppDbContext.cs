using Microsoft.EntityFrameworkCore;
using Organizer.Core.Models;

namespace Organizer.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>()
                .Property(p => p.ShortDescription)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Event>()
                .Property(p => p.LongDescription)
                .HasMaxLength(200);

            modelBuilder.Entity<User>()
                .Property(p => p.Login)
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(p => p.Password)
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(p => p.Name)
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(p => p.LastName)
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(p => p.Email)
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(p => p.Phone)
                .HasMaxLength(30);

            // TODO: Add foreign key relationship to user table.
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server =(localdb)\\MSSQLLocalDB; Database = OrganizerData; Trusted_Connection = True;");
        }
    }
}
