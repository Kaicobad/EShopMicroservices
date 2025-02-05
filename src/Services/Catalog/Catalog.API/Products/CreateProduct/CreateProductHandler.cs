using Catalog.API.Repository.Interfaces;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, Decimal Price) 
    : ICommand<CreateProductResult>;  //IRequest Inherited From [Mediate R]
public record CreateProductResult(string Message);
internal class CreateProductCommandHandler(IProductRepository _productRepository) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var response = await _productRepository.CreateProduct(command.Name, command.Category, command.Description, command.ImageFile, command.Price);
        return new CreateProductResult(response);
    }
}

