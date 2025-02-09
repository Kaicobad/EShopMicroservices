namespace Catalog.API.Products.GetProduct;

public record GetProductsQuery(int PageNumber, int PageSize) : IQuery<GetProductsResult>;
public record GetProductsResult(IEnumerable<Product> Products,int TotalCount);

public class GetProductsQueryHandler(IProductRepository _productRepository) : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var (Products,TotalCount) = await _productRepository.GetProducts(query.PageNumber, query.PageSize, cancellationToken);
        return new GetProductsResult(Products,TotalCount);
    }
}

