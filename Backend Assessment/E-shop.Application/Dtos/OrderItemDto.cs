namespace E_shop.Application.Dtos
{
    public record OrderItemDto(int ItemId, string ItemName, int Quantity);
    public record OrderItemCreateDto(int ItemId, int Quantity);
}
