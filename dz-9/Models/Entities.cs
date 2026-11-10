namespace dz_9.Models
{
    public class Product { public Guid Id { get; set; } = Guid.NewGuid(); public string Name { get; set; } = string.Empty; public decimal Price { get; set; } public DateTime? DeletedAt { get; set; } }
    public class ApiResponse<T> { public int Status { get; set; } public string Message { get; set; } = string.Empty; public T? Data { get; set; } public object? Error { get; set; } }
}
