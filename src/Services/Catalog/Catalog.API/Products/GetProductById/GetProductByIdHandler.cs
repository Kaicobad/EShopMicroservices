namespace Catalog.API.Products.GetProductById;

public record GetProductByIdQuery(Guid ProductId) : IQuery<GetProductByIdResult>;
public record GetProductByIdResult(Product Product);
public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
{
    public GetProductByIdQueryValidator()
    {
        RuleFor(x => x.ProductId).NotNull().NotEmpty().WithMessage("ProductId Not Supplied");
    }
}
public class GetProductByIdQueryHandler(IProductRepository _productRepository) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
       var product = await _productRepository.GetProductById(request.ProductId, cancellationToken);
        return new GetProductByIdResult(product);
    }
}
