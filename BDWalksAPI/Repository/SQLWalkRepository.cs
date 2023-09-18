using BDWalksAPI.Data;
using BDWalksAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BDWalksAPI.Repository
{
    public class SQLWalkRepository : IWalksReposity
    {
        private readonly BDWalkDbContext _context;

        public SQLWalkRepository(BDWalkDbContext context)
        {
            _context = context;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await _context.walks.AddAsync(walk);
            await _context.SaveChangesAsync();
            return walk;
        }
        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var existingWalks = await _context.walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalks == null)
            {
                return null;
            }
            _context.walks.Remove(existingWalks);
            await _context.SaveChangesAsync();
            return existingWalks;
        }
      

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? SortBy = null, bool isAcending = true, int pageNumber = 1, int pageSize = 1000)
        {
            var walks = _context.walks.Include("Region").Include("Difficulty").AsQueryable();
            //filtering
            if(string.IsNullOrWhiteSpace(filterOn)==false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
            }
            //sorting
            if (string.IsNullOrWhiteSpace(SortBy) == false)
            {
                if (SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks =isAcending? walks.OrderBy(x => x.Name): walks.OrderByDescending(x => x.Name);
                }
            }

            //pagination
            var skipResult = (pageNumber - 1) * pageSize;

            return await walks.Skip(skipResult).Take(pageSize).ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await _context.walks
                .Include("Region")
                .Include("Difficulty")
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existingwalks = await _context.walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingwalks == null)
            {
                return null;
            }
            existingwalks.Name = walk.Name;
            existingwalks.Description = walk.Description;
            existingwalks.LengthInKm = walk.LengthInKm;
            existingwalks.WalkImageUrl = walk.WalkImageUrl;
            existingwalks.RegionId = walk.RegionId;
            existingwalks.DifficultyId = walk.DifficultyId;
            await _context.SaveChangesAsync();
            return existingwalks;
        }

       
    }
}
