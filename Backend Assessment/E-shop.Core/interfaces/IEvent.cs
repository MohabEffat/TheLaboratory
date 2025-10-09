namespace E_shop.Core.interfaces
{
    public interface IEvent
    {
        int EventId { get; set; }
        DateTime OccurredOn => DateTime.Now;
        string EventType => GetType().AssemblyQualifiedName!;
        string Info { get; set; }
    }
}
