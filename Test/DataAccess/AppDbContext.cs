using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.API.DataAccess
{
    public class AppDbContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectBillingMode> BillingModes { get; set; } 
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
    }
}
