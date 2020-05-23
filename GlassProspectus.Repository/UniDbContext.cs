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
    }
}
