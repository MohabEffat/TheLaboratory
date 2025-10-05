namespace TheLaboratory.Model
{
    public class OrderCreatedMessage
    {
        public int OrderId { get; set; }
        public string Customer { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
