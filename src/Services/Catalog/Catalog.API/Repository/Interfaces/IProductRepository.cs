namespace Catalog.API.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<string> CreateProduct(string Name, List<string> Category, string Description, string ImageFile, Decimal Price);
        Task<(IEnumerable<Product> Products, int TotalCount)> GetProducts(int pageNumber,int pageSize, CancellationToken cancellationToken);
        Task<Product> GetProductById(Guid ProductId,CancellationToken cancellationToken);
        Task<IEnumerable<Product>> GetProductByCategory(string Category, CancellationToken cancellationToken);
        Task<bool> UpdateProduct(Guid ProductId, string Name, List<string> Category, string Description, string ImageFile, Decimal Price);
        Task<bool> DeleteProduct(Guid ProductId, CancellationToken cancellationToken);
    }
}
