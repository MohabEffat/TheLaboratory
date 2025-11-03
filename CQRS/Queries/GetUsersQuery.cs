using CQRS.Dtos;
using CQRS.Interfaces;

namespace CQRS.Queries
{
    public record GetUsersQuery : IQuery<GetUsersResult>;
    public record GetUsersResult(IEnumerable<UserDto> Users);

}
