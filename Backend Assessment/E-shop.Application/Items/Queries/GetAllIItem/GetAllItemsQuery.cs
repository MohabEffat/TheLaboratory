namespace E_shop.Application.Items.Queries.GetAllIItem
{
    public record GetAllItemsQuery : IRequest<GetAllItemsQueryResult>;
    public record GetAllItemsQueryResult(IReadOnlyList<ItemDto> Items);

}
