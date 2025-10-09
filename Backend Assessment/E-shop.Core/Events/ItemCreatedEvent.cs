using E_shop.Core.interfaces;

namespace E_shop.Core.Events
{
    public record ItemCreatedEvent(string ItemName) : IEvent
    {
        public int EventId { get; set; }
        public string Info
        {
            get => $"Item With Name{ItemName} has Created.";
            set { }
        }
    }
}
