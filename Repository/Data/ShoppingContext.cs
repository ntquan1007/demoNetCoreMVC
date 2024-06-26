using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Data
{
    public class ShoppingContext : DbContext { 
        public ShoppingContext(DbContextOptions<ShoppingContext> options)
        : base(options)
        { }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<LineItem> LineItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
