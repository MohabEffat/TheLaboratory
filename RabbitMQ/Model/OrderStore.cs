namespace TheLaboratory.Model
{
    public static class OrderStore
    {
        public static List<OrderCreatedMessage> Orders { get; } = new();
    }
}
