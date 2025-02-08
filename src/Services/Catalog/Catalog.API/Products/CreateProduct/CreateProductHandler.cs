namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, Decimal Price)
    : ICommand<CreateProductResult>;  //IRequest Inherited From [Mediate R]
public record CreateProductResult(string Message);

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name Is Required");
        RuleFor(x => x.Category).NotEmpty().WithMessage("Category Required");
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Image File Required");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price Required");

    }
}
internal class CreateProductCommandHandler(IProductRepository _productRepository, IValidator<CreateProductCommand> validator) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var result = await validator.ValidateAsync(command, cancellationToken);
        var error = result.Errors.Select(x => x.ErrorMessage).ToList();

        if (error.Any()) 
        {
          throw new ValidationException(error.FirstOrDefault());  
        }
        var response = await _productRepository.CreateProduct(command.Name, command.Category, command.Description, command.ImageFile, command.Price);
        return new CreateProductResult(response);
    }
}

