using Microsoft.EntityFrameworkCore;
using dz_8.Models;
namespace dz_8.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<TaskItem> Tasks { get; set; }
    }
}
