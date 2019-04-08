using Microsoft.EntityFrameworkCore;
using Organizer.Core.Models;

namespace Organizer.Core.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
