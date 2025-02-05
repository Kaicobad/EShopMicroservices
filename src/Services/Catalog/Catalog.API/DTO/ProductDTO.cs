namespace Catalog.API.DTO
{
    public class ProductDTO
    {
        public Guid ProductId { get; set; }
        public string? Name { get; set; }
        public List<string>? Category { get; set; }
        public string? Description { get; set; }
        public string? ImageFile { get; set; }
        public decimal Price { get; set; }
    }
}
