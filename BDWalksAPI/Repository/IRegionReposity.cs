using BDWalksAPI.Models.Domain;

namespace BDWalksAPI.Repository
{
    public interface IRegionReposity
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetByIdAsync(Guid id);
        Task<Region> CreatAsync(Region region);
        Task<Region?> UpdateAsync(Guid id, Region region);
        Task<Region?> DeleteAsync(Guid id);
    }
}
