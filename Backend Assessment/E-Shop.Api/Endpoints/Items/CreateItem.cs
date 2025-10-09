using E_shop.Application.Items.Commands.CreateItem;

namespace E_Shop.Api.Endpoints.Items
{
    public record CreateItemRequest(ItemDto Item);
    public record CreateItemResponse(int Id);
    public class CreateItem : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/items", async (CreateItemRequest request, IMediator sender) =>
            {
                var command = request.Adapt<CreateItemCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<CreateItemResponse>();

                return Results.Created($"/items/{response.Id}", response);
            })
            .WithName("CreateItem")
            .WithSummary("Creates a new item")
            .Produces<CreateItemResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest);

        }
    }
}
