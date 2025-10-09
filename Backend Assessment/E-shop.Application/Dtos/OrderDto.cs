namespace E_shop.Application.Dtos
{
    public record OrderDto(int Id, int CustomerId, List<OrderItemDto> OrderItems, decimal TotalPrice);
}
