namespace CQRS.Dtos
{
    public record UserDto (Guid Id, string FullName, string Email, string PasswordHash, string PhoneNumber, string Address);
}
