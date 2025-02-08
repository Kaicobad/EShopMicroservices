namespace Catalog.API.Products.UpdateProduct;

public record UpdateProductCommand(Guid ProductId,string Name, List<string> Category, string Description, string ImageFile, Decimal Price): ICommand<UpdateProductResult>;
public record UpdateProductResult(bool IsSuccess);
public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.ProductId).NotNull().NotEmpty().WithMessage("ProductId Not Supplied");

    }
}
public class UpdateProductCommandHandler(IProductRepository _productRepository) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var response = await _productRepository.UpdateProduct(command.ProductId, command.Name, command.Category, command.Description, command.ImageFile, command.Price);
        return new UpdateProductResult(response);
    }
}
