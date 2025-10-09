namespace E_shop.Application.Dtos
{
    public record OrderDto(int CustomerId, List<OrderItemDto> Items);

}
