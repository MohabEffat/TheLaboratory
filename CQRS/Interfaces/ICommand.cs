using MediatR;

namespace CQRS.Interfaces
{
    public interface ICommand : ICommand<Unit>
    {
    }
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
