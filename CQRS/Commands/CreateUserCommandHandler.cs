using CQRS.DbContexts;
using CQRS.Interfaces;
using CQRS.Models;

namespace CQRS.Commands
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, CreateUserResult>
    {
        private readonly AppDbContext _context;

        public CreateUserCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateUserResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                FullName = command.User.FullName,
                Email = command.User.Email,
                PasswordHash = command.User.PasswordHash,
                PhoneNumber = command.User.PhoneNumber,
                Address = command.User.Address,
                IsActive = true
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return new CreateUserResult(user.Id);
        }
    }
}
