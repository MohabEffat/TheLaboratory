using E_shop.Application.Orders.Queries.GetAllOrder;

namespace E_Shop.Api.Endpoints.Orders
{
    public class GetAllOrders : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet ("/orders", async (IMediator mediator) =>
            {
                var query = new GetAllOrdersQuery();

                var result = await mediator.Send(query);

                return Results.Ok(result);
            })
            .WithName("GetAllOrders")
            .WithSummary("Gets all orders")
            .Produces<GetAllOrdersResult>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound);

        }
    }
}
