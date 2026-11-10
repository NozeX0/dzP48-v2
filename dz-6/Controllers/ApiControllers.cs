using Microsoft.AspNetCore.Mvc;
using dz_6.Services;
namespace dz_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetLogs() => Ok(LoggingMiddleware.Logs);
    }
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IShoppingCartService _cart;
        public CartController(IShoppingCartService cart) { _cart = cart; }
        [HttpPost]
        public IActionResult Add(string item)
        {
            _cart.AddProduct(item);
            return Ok(new { Status = 200, Message = "Added", Data = _cart.GetProducts() });
        }
    }
}
