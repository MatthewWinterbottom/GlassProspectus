using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GlassProspectus.Repository
{
    public class UniDbContext : IdentityDbContext
    {
        public UniDbContext(DbContextOptions<UniDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Rename default 'AspNet' tables to remove the 'AspNet' bit e.g 'AspNetUsers' to 'Users'

            builder.Entity<IdentityUser>(entity => entity.ToTable(name: "Users"));

            builder.Entity<IdentityUserRole<string>>(entity => entity.ToTable(name: "UserRoles"));

            builder.Entity<IdentityRole>(entity => entity.ToTable(name: "Roles"));

            builder.Entity<IdentityUserClaim<string>>(entity => entity.ToTable(name: "UserClaims"));

            builder.Entity<IdentityUserLogin<string>>(entity => entity.ToTable(name: "UserLogins"));

            builder.Entity<IdentityRoleClaim<string>>(entity => entity.ToTable(name: "RoleClaims"));

            builder.Entity<IdentityUserToken<string>>(entity => entity.ToTable(name: "UserTokens"));
        }
    }
}
