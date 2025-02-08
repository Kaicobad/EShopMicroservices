namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductCommand(Guid ProductId) : ICommand<DeleteProductResult>;
public record DeleteProductResult(bool IsDeleted);

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.ProductId).NotNull().NotEmpty().WithMessage("ProductId Not Supplied");
    }
}
public class DeleteProductCommandHandler(IProductRepository _productRepository) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var response = await _productRepository.DeleteProduct(request.ProductId, cancellationToken);
        return new DeleteProductResult(response);
    }
}
