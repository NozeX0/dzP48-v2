using Microsoft.EntityFrameworkCore; using dz_10.Models;
namespace dz_10.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductImage>().HasOne(p => p.Product).WithMany(p => p.Images).HasForeignKey(p => p.ProductId);
        }
    }
}
