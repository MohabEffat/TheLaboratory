using E_shop.Application.Orders.Commands.CreateOrder;

namespace E_Shop.Api.Endpoints.Orders
{
    public class CreateOrder : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/orders", async (CreateOrderCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);

                return Results.Created($"/orders/{result.Id}", result);
            })
            .WithName("CreateOrder")
            .WithSummary("Creates a new order")
            .Produces(StatusCodes.Status201Created)
            .ProducesValidationProblem()
            .ProducesProblem(StatusCodes.Status500InternalServerError);
        }
    }
}
