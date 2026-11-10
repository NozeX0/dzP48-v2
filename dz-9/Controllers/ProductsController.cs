using Microsoft.AspNetCore.Mvc; using Microsoft.EntityFrameworkCore; using dz_9.Data; using dz_9.Models;
namespace dz_9.Controllers
{
    [Route("api/products")] [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context; public ProductsController(AppDbContext context) { _context = context; }
        [HttpGet]
        public async Task<IActionResult> GetProducts() { var p = await _context.Products.Where(x => x.DeletedAt == null).ToListAsync(); return Ok(new ApiResponse<IEnumerable<Product>> { Status = 200, Message = "Ok", Data = p }); }
        [HttpDelete("{id}/soft")]
        public async Task<IActionResult> SoftDelete(Guid id) { var p = await _context.Products.FindAsync(id); if (p == null) return NotFound(); p.DeletedAt = DateTime.UtcNow; await _context.SaveChangesAsync(); return Ok(new ApiResponse<object> { Status = 200, Message = "Soft deleted" }); }
    }
}
