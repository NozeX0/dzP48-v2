namespace dz_10.Models
{
    public class Product { public Guid Id { get; set; } = Guid.NewGuid(); public string Name { get; set; } = string.Empty; public List<ProductImage> Images { get; set; } = new(); }
    public class ProductImage { public Guid Id { get; set; } = Guid.NewGuid(); public Guid ProductId { get; set; } public string ImageUrl { get; set; } = string.Empty; public Product Product { get; set; } = null!; }
}
