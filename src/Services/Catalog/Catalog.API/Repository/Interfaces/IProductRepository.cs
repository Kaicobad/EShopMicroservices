namespace Catalog.API.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<string> CreateProduct(string Name, List<string> Category, string Description, string ImageFile, Decimal Price);
        Task<IEnumerable<Product>> GetProducts( CancellationToken cancellationToken);
    }
}
