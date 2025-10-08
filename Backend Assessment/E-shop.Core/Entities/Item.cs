namespace E_shop.Core.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int QuantityInStock { get; set; }
        public decimal Price { get; set; }
    }
}
