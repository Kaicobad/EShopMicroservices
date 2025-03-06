namespace Catalog.API.Products.GetProduct;

public record GetProductsResponse(IEnumerable<Product> Products, int TotalCount);

public class GetProductsEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (ISender sender, int pageNumber = 1, int pageSize = 10) =>
        {
            var result = await sender.Send(new GetProductsQuery(pageNumber, pageSize));
            var response = new GetProductsResponse(result.Products, result.TotalCount);
            return Results.Ok(response);
        })
        .WithName("GetProducts")
        .Produces<GetProductsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("GetProducts")
        .WithDescription("Get Products");
    }
}

