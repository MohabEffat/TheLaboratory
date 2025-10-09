using E_shop.Application.Orders.Commands.DeleteOrder;

namespace E_Shop.Api.Endpoints.Orders
{
    public class DeleteOrder : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete ("/orders/{id}", async (int id, IMediator mediator) =>
            {
                var command = new DeleteOrderCommand(id);

                var result = await mediator.Send(command);

                return Results.Ok(result.IsSuccess);
            })
            .WithName("DeleteOrder")
            .WithSummary("Deletes an order by ID")
            .Produces<DeleteOrderResult>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound);
        }
    }
}
