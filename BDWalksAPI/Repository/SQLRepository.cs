using BDWalksAPI.Data;
using BDWalksAPI.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BDWalksAPI.Repository
{
    public class SQLRepository : IRegionReposity
    {
        private readonly BDWalkDbContext _dbContext;

        public SQLRepository(BDWalkDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Region>> GetAllAsync()
        {
            return await _dbContext.regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await _dbContext.regions.FirstOrDefaultAsync(x => x.Id == id);
        }
        public  async Task<Region> CreatAsync(Region region)
        {
            await _dbContext.regions.AddAsync(region);
            await _dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var existingRegion = await _dbContext.regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }
            _dbContext.regions.Remove(existingRegion);
            await _dbContext.SaveChangesAsync();
            return existingRegion;
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await _dbContext.regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }
            existingRegion.Name = region.Name;
            existingRegion.Code = region.Code;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            await _dbContext.SaveChangesAsync();
            return existingRegion;
        }
    }
}
