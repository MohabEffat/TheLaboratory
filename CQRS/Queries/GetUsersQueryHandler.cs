using CQRS.DbContexts;
using CQRS.Dtos;
using CQRS.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Queries
{
    public class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, GetUsersResult>
    {
        private readonly AppDbContext _context;
        public GetUsersQueryHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<GetUsersResult> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.Users.ToListAsync();

            var userDtos = users.Select(user => new UserDto(
                
                user.Id,
                user.FullName,
                user.Email,
                user.PasswordHash,
                user.PhoneNumber!,
                user.Address!
            ));
            return new GetUsersResult(userDtos);
        }
    }
}
