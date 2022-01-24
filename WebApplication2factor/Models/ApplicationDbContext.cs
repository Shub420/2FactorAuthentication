using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace WebApplication2factor.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(): base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        
    }
}