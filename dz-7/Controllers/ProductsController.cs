using Microsoft.AspNetCore.Mvc;
namespace dz_7.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static readonly List<string> products = Enumerable.Range(1, 100).Select(i => $"Product {i}").ToList();
        [HttpGet]
        public IActionResult GetProducts([FromQuery] int? startFrom, [FromQuery] int? endsWith)
        {
            if (!startFrom.HasValue && !endsWith.HasValue) return Ok(new { Status = 200, Message = "Ok", Products = products });
            if (startFrom.HasValue && (startFrom.Value < 0 || startFrom.Value >= products.Count)) return BadRequest(new { Status = 400, Message = $"Start from must be in 0-{products.Count - 1}" });
            if (endsWith.HasValue && (endsWith.Value < 0 || endsWith.Value >= products.Count)) return BadRequest(new { Status = 400, Message = $"endsWith must be in 0-{products.Count - 1}" });
            if (startFrom.HasValue && endsWith.HasValue && startFrom.Value > endsWith.Value) return BadRequest(new { Status = 400, Message = "startFrom cannot be greater than endsWith" });
            int start = startFrom ?? 0; int end = endsWith ?? (products.Count - 1); int count = end - start + 1;
            return Ok(new { Status = 200, Message = "Ok", Products = products.GetRange(start, count) });
        }
    }
}
