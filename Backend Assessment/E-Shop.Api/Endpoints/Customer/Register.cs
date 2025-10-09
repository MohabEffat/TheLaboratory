namespace E_Shop.Api.Endpoints.Customer
{
    public record registerRequest(RegisterDto Register);
    public record registerResponse(string Email);
    public class Register : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/customers/register", async (registerRequest request, IMediator mediator) =>
            {
                var command = request.Adapt<RegisterCommand>();

                var result = await mediator.Send(command);

                var response = result.Adapt<registerResponse>();

                return Results.Ok(response);
            })
            .WithName("Register")
            .Produces<registerResponse>(StatusCodes.Status200OK)
            .ProducesValidationProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Register a new customer")
            .WithDescription("Creates a new customer and returns login info or token.");

        }
    }
}
