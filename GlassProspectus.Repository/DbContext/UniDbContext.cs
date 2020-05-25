using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GlassProspectus.Repository
{
    public class UniDbContext : ApiAuthorizationDbContext<IdentityUser> //IdentityDbContext
    {
        public UniDbContext(DbContextOptions options,
                            IOptions<OperationalStoreOptions> opertaionalStoreOptions)
                                : base(options, opertaionalStoreOptions) { }

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
