namespace E_shop.Application.Dtos
{
    public record OrderDto(int Id,int CustomerId, List<OrderItemDto> OrderItems, decimal TotalPrice);

    public record OrderCreateDto(int CustomerId, List<OrderItemCreateDto> OrderItems);
}
