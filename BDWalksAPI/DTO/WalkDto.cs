using BDWalksAPI.Models.Domain;

namespace BDWalksAPI.DTO
{
    public class WalkDto 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public Region Region { get; set; }
        public Difficulty Difficulty { get; set; }

    }
}
