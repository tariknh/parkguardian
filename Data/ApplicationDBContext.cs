using Microsoft.EntityFrameworkCore;
using ParkGuard.Models;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Guard> Guards { get; set; }

        // Class implementation goes here
    }
}