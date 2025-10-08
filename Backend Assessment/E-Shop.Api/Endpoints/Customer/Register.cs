using Carter;
using E_shop.Application.Dtos;
using E_shop.Application.Users.Commands.Register;
using Mapster;
using MediatR;

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
            .WithTags("Customer")
            .WithName("Register")
            .Produces<registerResponse>(StatusCodes.Status200OK)
            .ProducesValidationProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Register a new customer")
            .WithDescription("Creates a new customer and returns login info or token.");

        }
    }
}
