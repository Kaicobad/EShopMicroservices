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

    public async Task<bool> DeleteProduct(Guid ProductId, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _catalogContext.Products.FindAsync(ProductId,cancellationToken);
            if (response == null)
            {
                return false;
            }
            else 
            {
                _catalogContext.Remove(response);
                await _catalogContext.SaveChangesAsync(cancellationToken);
                return true;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<Product>> GetProductByCategory(string Category, CancellationToken cancellationToken)
    {
        try
        {
            var product = await (from p in _catalogContext.Products
                           where p.Category.Contains(Category)
                           select p).ToListAsync();
            return product;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Product> GetProductById(Guid ProductId, CancellationToken cancellationToken)
    {
        try
        {
            var product = await _catalogContext.Products.Where(x => x.ProductId == ProductId).FirstOrDefaultAsync(cancellationToken);

            if (product == null)
            {
                throw new ProductNotFoundException(ProductId);
            }
            return product;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<(IEnumerable<Product> Products, int TotalCount)> GetProducts(int pageNumber,int pageSize,CancellationToken cancellationToken)
    {
        try
        {
            var query = _catalogContext.Products.AsQueryable();
            int totalCount = await query.CountAsync();
            var productList = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
             return (productList, totalCount);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public Task<bool> UpdateProduct(Guid ProductId, string Name, List<string> Category, string Description, string ImageFile, decimal Price)
    {
        try
        {
          var respose = _catalogContext.Products.Where(x => x.ProductId == ProductId).FirstOrDefault();
            if (respose != null)
            {
                respose.Name = Name;
                respose.Category = Category;
                respose.Description = Description;
                respose.ImageFile = ImageFile;
                respose.Price = Price;
                _catalogContext.Products.Update(respose);
                _catalogContext.SaveChanges();
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            } 
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
