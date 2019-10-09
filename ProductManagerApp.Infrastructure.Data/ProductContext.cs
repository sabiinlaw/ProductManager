using ProductManagerApp.Domain.Core;
using System.Data.Entity;

namespace ProductManagerApp.Infrastructure.Data
{
    public class ProductContext :DbContext
    {
        public ProductContext()
            : base("ProductContext")
        { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
