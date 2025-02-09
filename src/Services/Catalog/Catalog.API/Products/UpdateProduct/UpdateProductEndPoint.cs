namespace Catalog.API.Products.UpdateProduct;

public record UpdateProductRequest(Guid ProductId, string Name, List<string> Category, string Description, string ImageFile, Decimal Price);
public class UpdateProductEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/products/update",
       async (UpdateProductRequest request, ISender sender) =>
       {
           var command = request.Adapt<UpdateProductCommand>();
           var result = await sender.Send(command);
           var response = result.Adapt<UpdateProductResult>();

           return Results.Ok(response);
       })
   .WithDisplayName("UpdateProduct")
   .Produces<CreateProductResult>(StatusCodes.Status201Created)
   .ProducesProblem(StatusCodes.Status400BadRequest)
   .WithSummary("Updates product")
   .WithDescription("Updates an existing product in the catalog");
    }
}
