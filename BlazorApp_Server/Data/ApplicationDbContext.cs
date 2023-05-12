using BlazorApp_Server.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp_Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; } = null!;
    }
}
