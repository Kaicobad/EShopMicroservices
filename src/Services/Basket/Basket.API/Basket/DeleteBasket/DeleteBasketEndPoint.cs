
namespace Basket.API.Basket.DeleteBasket;

public  record DeleteBasketRequest(string UserName);

public class DeleteBasketEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/basket/{UserName}", async (string UserName, ISender send) =>
        {
            var result = await send.Send(new DeleteBasketCommand(UserName));
            var response = result.Adapt<DeleteBasketResult>();
            return Results.Ok(response);
        }).WithDisplayName("Delete Basket")
        .Produces<DeleteBasketResult>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete product")
        .WithDescription("Delete basket from qeue");

    }
}
