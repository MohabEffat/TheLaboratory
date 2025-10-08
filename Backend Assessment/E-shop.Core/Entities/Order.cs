namespace E_shop.Core.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = default!;
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public decimal TotalPrice
        {
            get => OrderItems.Sum(oi => oi.Item.Price * oi.Quantity);
            private set { }
        }
    }
}
