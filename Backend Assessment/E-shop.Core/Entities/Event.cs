using E_shop.Core.interfaces;
using System.ComponentModel.DataAnnotations;

namespace E_shop.Core.Entities
{
    public class Event : IEvent
    {
        [Key]
        public int EventId { get; set; }
        public DateTime OccurredOn { get; init; } = DateTime.UtcNow;
        public string EventType { get; set; } = string.Empty;
        public string Info { get; set; } = string.Empty;
    }
}
