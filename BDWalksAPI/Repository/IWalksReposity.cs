using BDWalksAPI.Models.Domain;

namespace BDWalksAPI.Repository
{
    public interface IWalksReposity
    {
        Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null,string? SortBy = null,bool isAcending = true,int pageNumber =1,int pageSize=1000);
        Task<Walk?> GetByIdAsync(Guid id);
        Task<Walk> CreateAsync(Walk walk);
        Task<Walk?> UpdateAsync(Guid id, Walk walk);
        Task<Walk?> DeleteAsync(Guid id);
    }
}
