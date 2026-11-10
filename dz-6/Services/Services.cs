namespace dz_6.Services
{
    public interface IShoppingCartService { void AddProduct(string product); List<string> GetProducts(); }
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly List<string> _cart = new();
        public void AddProduct(string product) => _cart.Add(product);
        public List<string> GetProducts() => _cart;
    }
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public static readonly List<string> Logs = new();
        public LoggingMiddleware(RequestDelegate next) { _next = next; }
        public async Task InvokeAsync(HttpContext context)
        {
            var log = $"{DateTime.Now} | {context.Request.Method} | {context.Request.Path}";
            Console.WriteLine(log);
            Logs.Add(log);
            await _next(context);
        }
    }
}
