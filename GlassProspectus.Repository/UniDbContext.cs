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
                    .ToTable("Users")
                    .Property(p => p.Id)
                    .HasColumnName("UserId");

            builder.Entity<IdentityUserRole<>>().ToTable("MyUserRoles");
        }
    }
}
