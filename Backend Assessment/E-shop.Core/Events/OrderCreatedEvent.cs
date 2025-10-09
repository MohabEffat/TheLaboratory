using E_shop.Core.interfaces;

namespace E_shop.Core.Events
{
    public record OrderCreatedEvent(int CustomerId) : IEvent
    {
        public int EventId { get; set; }
        public string Info
        {
            get => $"Order with CustomerId: {CustomerId} has Created.";
            set { }
        }
    }
}
