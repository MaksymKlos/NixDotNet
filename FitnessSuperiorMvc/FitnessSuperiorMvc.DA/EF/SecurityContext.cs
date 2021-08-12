using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace FitnessSuperiorMvc.DA.EF
{
    public sealed class SecurityContext : IdentityDbContext<IdentityUser>
    { 
        public SecurityContext()
        {

        }
        public SecurityContext(DbContextOptions<SecurityContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
