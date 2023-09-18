using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BDWalksAPI.Data
{
    public class WalksAuthDbContext:IdentityDbContext
    {
        public WalksAuthDbContext(DbContextOptions<WalksAuthDbContext> options):base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var readerRoleId = "a3c5a772-51e8-4560-8676-8530380cabc4";
            var writerRoleId = "83bd4e5f-fda3-4884-8789-cb54140215fa";

            var Roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Id= readerRoleId,
                    ConcurrencyStamp=readerRoleId,
                    Name ="Reader",
                    NormalizedName ="Reader".ToUpper()
                },
                new IdentityRole()
                {
                    Id= writerRoleId,
                    ConcurrencyStamp=writerRoleId,
                    Name ="Writer",
                    NormalizedName ="Writer".ToUpper()
                }
            };
            builder.Entity<IdentityRole>().HasData(Roles);

        }
    }
}
