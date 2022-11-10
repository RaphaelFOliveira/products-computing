using Microsoft.EntityFrameworkCore;
using ProductsComputing.Model;

namespace ProductsComputing.Infra.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Stock> Stock { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
