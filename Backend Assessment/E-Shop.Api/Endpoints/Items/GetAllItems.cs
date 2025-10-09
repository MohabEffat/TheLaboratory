using E_shop.Application.Items.Queries.GetAllIItem;

namespace E_Shop.Api.Endpoints.Items
{
    public class GetAllItems : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/items", async (IMediator mediator) =>
            {
                var query = new GetAllItemsQuery();
                var result = await mediator.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetAllItems")
            .WithSummary("Gets all items")
            .Produces<GetAllItemsQueryResult>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound);
        }
    }
}
