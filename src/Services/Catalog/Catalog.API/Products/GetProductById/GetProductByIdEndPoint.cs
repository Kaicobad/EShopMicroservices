namespace Catalog.API.Products.GetProductById;
public class GetProductByIdEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{productId}", async (ISender sender, Guid productId) =>
        {
            var result = await sender.Send(new GetProductByIdQuery(productId));
            var response = result.Adapt<GetProductByIdResult>();
            return Results.Ok(response);
        })  .WithName("GetProductById")
            .Produces<GetProductByIdResult>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Product ById")
            .WithDescription("Get Product By Id");
    }
}

