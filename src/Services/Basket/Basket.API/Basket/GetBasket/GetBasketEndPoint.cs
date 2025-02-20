namespace Basket.API.Basket.GetBasket;

public class GetBasketEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{userName}", async (string userName, ISender sender) =>
        {
            var result = await sender.Send(new GetBasketQuery(userName));
            var response = result.Adapt<GetBasketResult>();
            return Results.Ok(response);
        })
            .WithName("Get Basket")
            .Produces<GetBasketResult>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get basket ")
            .WithDescription("Get Basket");
    }
}
