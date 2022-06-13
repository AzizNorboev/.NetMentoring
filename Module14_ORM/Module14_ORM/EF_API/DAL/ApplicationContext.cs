using Microsoft.EntityFrameworkCore;
using Models;

namespace EF_API.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "product1",
                Description = "desc1",
                Weight = 10,
                Height = 10,
                Width = 10,
                Length = 10
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "product2",
                Description = "desc2",
                Weight = 11,
                Height = 12,
                Width = 11,
                Length = 12
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = 1,
                Status = Models.enums.Status.Loading,
                ProductId = 1
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = 2,
                Status = Models.enums.Status.Arrived,
                ProductId = 2
            });
        }
    }
}
