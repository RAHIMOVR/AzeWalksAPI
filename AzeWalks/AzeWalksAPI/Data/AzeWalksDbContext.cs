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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("da48028d-23a1-487c-9e3c-245dc0b57332"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("451ead80-3cc6-4039-ae9b-96bb4163e8c9"),
                    Name = "Normal"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("d1b35171-8580-4302-b1bd-db3203ea969d"),
                    Name = "Hard"
                }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);
        }
    }
}
