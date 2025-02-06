
using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.DeleteProduct;


public class DeleteProductEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/delete/{productId}", async (Guid productId, ISender sender) =>
        {
            var result = await sender.Send(new DeleteProductCommand(productId));
            var response = result.Adapt<DeleteProductResult>();
            return Results.Ok(response);
        })
            .WithName("DeleteProduct")
       .WithDisplayName("DeleteProduct")
       .Produces<CreateProductResult>(StatusCodes.Status201Created)
       .ProducesProblem(StatusCodes.Status400BadRequest)
       .ProducesProblem(StatusCodes.Status404NotFound)
       .WithSummary("Delete product")
       .WithDescription("Delete existing product in the catalog");
    }
}
