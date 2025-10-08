namespace E_shop.Core.Entities
{
    public class OrderItem
    {
        public int OrderId { get; set; }
        public Order Order { get; set; } = default!;
        public int ItemId { get; set; }
        public Item Item { get; set; } = default!;
        public int Quantity { get; set; }
    }
}
