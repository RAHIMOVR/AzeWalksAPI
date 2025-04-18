using Microsoft.EntityFrameworkCore;
using AzeWalksAPI.Data;
using AzeWalksAPI.Models.Domain;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AzeWalksAPI.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly AzeWalksDbContext dbContext;

        public SQLRegionRepository(AzeWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Region> CreateAsync(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync(); 
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var existingRegions = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            
            if (existingRegions == null)
            {
                return null;
            }

            dbContext.Regions.Remove(existingRegions);
            await dbContext.SaveChangesAsync();
            return existingRegions;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();  
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x =>x.Id == id);  
            
            if (existingRegion == null)
            {
                return null;
            }

            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            await dbContext.SaveChangesAsync();
            return existingRegion;
        }
    }
}
