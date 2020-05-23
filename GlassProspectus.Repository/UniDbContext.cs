using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GlassProspectus.Repository
{
    public class UniDbContext : IdentityDbContext
    {
        public UniDbContext(DbContextOptions<UniDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityUser>()
                    .ToTable("Users");

            builder.Entity<IdentityUserRole<string>>()
                    .ToTable("UserRoles");

            builder.Entity<IdentityUserToken<string>>()
                    .ToTable("UserTokens");

            builder.Entity<IdentityUserClaim<int>>()
                .ToTable("UserClaims");

            builder.Entity<IdentityUserLogin<string>>()
                    .ToTable("UserLogins");

            builder.Entity<IdentityRole>()
                    .ToTable("Roles");

            builder.Entity<IdentityRoleClaim<int>>()
                .ToTable("UserRoleClaims");
        }
    }
}
