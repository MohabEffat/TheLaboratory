namespace E_shop.Application.Orders.Queries.GetAllOrder
{
    public record GetAllOrdersQuery : IRequest<GetAllOrdersResult>;
    public record GetAllOrdersResult(IReadOnlyList<OrderDto> Orders);

}
