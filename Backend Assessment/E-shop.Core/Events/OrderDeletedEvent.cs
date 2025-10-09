using E_shop.Core.interfaces;

namespace E_shop.Core.Events
{
    public record OrderDeletedEvent (int OrderId) : IEvent
    {
        public int EventId { get; set; }
        public string Info
        {
            get => $"Order with CustomerId: {OrderId} has Deleted.";
            set { }
        }
    }

}
