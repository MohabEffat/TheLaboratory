using E_shop.Application.Orders.Queries.GetOrderByCustomerId;

namespace E_Shop.Api.Endpoints.Orders
{
    public class GetOrdersByCustomerId : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders/customer/{customerId}", async (int customerId, IMediator mediator) =>
            {
                var query = new GetOrdersByCustomerIdCommand(customerId);

                var orders = await mediator.Send(query);

                return Results.Ok(orders);
            })
            .WithName("GetOrdersByCustomerId")
            .WithSummary("Gets all orders for a specific customer by their ID")
            .Produces<List<GetOrdersByCustomerIdResult>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError);

        }
    }
}
