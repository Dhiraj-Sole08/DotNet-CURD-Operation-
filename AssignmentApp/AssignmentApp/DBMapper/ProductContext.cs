using AssignmentApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AssignmentApp.DBMapper
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory { ID = 1, Name = "Electronics", Description = "Electronic items" },
                new ProductCategory { ID = 2, Name = "Clothing", Description = "Apparel and clothing" }
            );
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}
