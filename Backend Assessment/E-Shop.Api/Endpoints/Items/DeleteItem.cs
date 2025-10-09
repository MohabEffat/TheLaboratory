using E_shop.Application.Items.Commands.DeleteItem;

namespace E_Shop.Api.Endpoints.Items
{
    public class DeleteItem : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/items/{id}", async (int id, IMediator mediator) =>
            {
                var command = new DeleteItemCommand(id);

                var result = await mediator.Send(command);

                return Results.Ok(result);
            })
            .WithName("DeleteItem")
            .WithSummary("Deletes an item by ID")
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status404NotFound);
        }
    }
}
