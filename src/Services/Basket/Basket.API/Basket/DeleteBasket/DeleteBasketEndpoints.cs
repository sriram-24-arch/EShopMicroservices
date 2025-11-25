
using Basket.API.Basket.GetBasket;

namespace Basket.API.Basket.DeleteBasket
{

    public record DelelteBasketResponse(bool IsSuccess);
    public class DeleteBasketEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/basket/{userName}", async (string userName, ISender sender) =>
            {
                var result = await sender.Send(new DeleteBasketCommand(userName));

                var response = result.Adapt<DelelteBasketResponse>();

                return Results.Ok(response);
            })
           .WithName("DeleteBasket")
           .Produces<DelelteBasketResponse>(StatusCodes.Status200OK)
           .ProducesProblem(StatusCodes.Status400BadRequest)
           .WithSummary("Delete Basket")
           .WithDescription("Delete Basket");
        }
    }
}
