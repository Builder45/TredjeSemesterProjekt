using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BeboerWeb.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var hasher = new PasswordHasher<IdentityUser>();
            modelBuilder.Entity<IdentityUser>().HasData(
                new List<IdentityUser>
                {
                    new IdentityUser
                    {
                        Id = "bbbbbbbb-1111-4182-9aff-081c3ae53433",
                        UserName = "badmin@beboerweb.dk",
                        NormalizedUserName = "BADMIN@BEBOERWEB.DK",
                        PasswordHash = hasher.HashPassword(null, "badmin")
                    },
                    new IdentityUser
                    {
                        Id = "bbbbbbbb-2222-4182-9aff-081c3ae53433",
                        UserName = "bruger@beboerweb.dk",
                        NormalizedUserName = "BRUGER@BEBOERWEB.DK",
                        PasswordHash = hasher.HashPassword(null, "bruger")
                    }
                    ,
                    new IdentityUser
                    {
                        Id = "bbbbbbbb-3333-4182-9aff-081c3ae53433",
                        UserName = "lejeren@beboerweb.dk",
                        NormalizedUserName = "LEJEREN@BEBOERWEB.DK",
                        PasswordHash = hasher.HashPassword(null, "lejeren")
                    }
                    ,
                    new IdentityUser
                    {
                        Id = "bbbbbbbb-4444-4182-9aff-081c3ae53433",
                        UserName = "vicevært@beboerweb.dk",
                        NormalizedUserName = "VICEVÆRT@BEBOERWEB.DK",
                        PasswordHash = hasher.HashPassword(null, "vicevært")
                    }
                }
            );
            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(
                new List<IdentityUserClaim<string>>
                {
                    new IdentityUserClaim<string>
                    {
                        Id = 1,
                        UserId = "bbbbbbbb-1111-4182-9aff-081c3ae53433",
                        ClaimType = "IsBa",
                        ClaimValue = "Yes"
                    },
                    new IdentityUserClaim<string>
                    {
                        Id = 2,
                        UserId = "bbbbbbbb-4444-4182-9aff-081c3ae53433",
                        ClaimType = "IsVV",
                        ClaimValue = "Yes"
                    },
                    //new IdentityUserClaim<string>
                    //{
                    //    Id = 3,
                    //    UserId = "bbbbbbbb-3333-4182-9aff-081c3ae53433",
                    //    ClaimType = "IsLejer",
                    //    ClaimValue = "Yes"
                    //}
                }
                );
        }
    }
}