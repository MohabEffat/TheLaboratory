namespace E_Shop.Api.Endpoints.Customer
{
    public record loginRequest(LoginDto Login);
    public record loginResponse(bool IsSuccess);
    public class Login : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/customers/login", async (loginRequest request, IMediator mediator) =>
            {
                var command = request.Adapt<LoginCommand>();

                var result = await mediator.Send(command);

                if (!result.IsSuccess)
                    return Results.BadRequest(result);

                var response = result.Adapt<loginResponse>();

                return Results.Ok(response);
            })
            .WithTags("Customer")
            .WithName("Login")
            .WithSummary("Authenticate a customer")
            .WithDescription("Logs in a customer using their email and password")
            .Produces<loginResponse>(StatusCodes.Status200OK)
            .ProducesValidationProblem(StatusCodes.Status400BadRequest);
        }
    }
}
