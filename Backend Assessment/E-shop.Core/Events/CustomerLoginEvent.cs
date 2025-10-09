using E_shop.Core.interfaces;

namespace E_shop.Core.Events
{
    public record CustomerLoginEvent(string Email) : IEvent
    {
        public int EventId { get; set; }
        public string Info
        {
            get => $"Customer with email {Email} has signed in.";
            set { }
        }

    }
}
