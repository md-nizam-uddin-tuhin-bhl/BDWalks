using BDWalksAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BDWalksAPI.Data
{
    public class BDWalkDbContext : DbContext
    {
        public BDWalkDbContext(DbContextOptions<BDWalkDbContext> options) : base(options) { }
        public DbSet<Walk> walks { get; set; }
        public DbSet<Difficulty> difficulties { get; set; }
        public DbSet<Region> regions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data for difficulty
            var difficulty = new List<Difficulty>() {

                new Difficulty()
                {
                    Id =Guid.Parse("766b3e6c-5c11-45f6-bc0d-0171a24857ff"),
                    Name ="Easy"
                },
                new Difficulty()
                {
                    Id =Guid.Parse("5ba1df2a-0d81-4c68-bc46-d754068a71a5"),
                    Name ="Medium"
                },
                new Difficulty()
                {
                    Id =Guid.Parse("9b99b0df-f4e6-4e7b-ae65-02ab2f5c9181"),
                    Name ="Hard"
                }
            };
            //seed  difficulty to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulty);

            //sedd data for region
            var region = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("0ce38c42-8184-4d45-96c3-be74625dcfe7"),
                    Name = "Dhaka",
                    Code = "Dha",
                    RegionImageUrl = "www.http://Dhaka.com"
                },
                 new Region()
                {
                    Id = Guid.Parse("b6433f36-693e-469c-a754-3e78a90a5534"),
                    Name = "Barisal",
                    Code = "Bar",
                    RegionImageUrl = "www.http://Barisal.com"
                },
                 new Region()
                {
                    Id = Guid.Parse("454186c6-0fdf-4fc2-8d4d-5f6d592441ba"),
                    Name = "Sylhet",
                    Code = "Sy",
                    RegionImageUrl = "www.http://Sylhet.com"
                }
            };

            //seed  difficulty to the database
            modelBuilder.Entity<Region>().HasData(region);

        }

    }
}
