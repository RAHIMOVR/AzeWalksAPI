using AzeWalksAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AzeWalksAPI.Data
{
    public class AzeWalksDbContext: DbContext
    {
        public AzeWalksDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
    }
}
