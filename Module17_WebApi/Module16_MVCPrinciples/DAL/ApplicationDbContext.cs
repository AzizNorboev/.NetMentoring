using DAL.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<SupplierEntity> Suppliers { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
    }
}
