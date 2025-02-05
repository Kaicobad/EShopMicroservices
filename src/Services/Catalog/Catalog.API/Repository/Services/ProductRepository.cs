
namespace Catalog.API.Repository.Services;

public class ProductRepository(CatalogContext _catalogContext) : IProductRepository
{
    public async Task<string> CreateProduct(string Name, List<string> Category, string Description, string ImageFile, Decimal Price)
    {
		try
		{
			  var product = new Product
              {
                  ProductId = Guid.NewGuid(),
                  Name = Name,
                  Category = Category,
                  Description = Description,
                  ImageFile = ImageFile,
                  Price = Price
              };

            _catalogContext.Products.Add(product);
            await _catalogContext.SaveChangesAsync();
            return product.Name;
        }
		catch (Exception ex)
		{
            return ex.Message;
		}
    }

    public async Task<IEnumerable<Product>> GetProducts(CancellationToken cancellationToken)
    {
        try
        {
             var products = await _catalogContext.Products.ToListAsync(cancellationToken);
            return products;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
