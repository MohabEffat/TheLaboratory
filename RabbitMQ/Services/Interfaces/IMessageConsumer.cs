namespace TheLaboratory.Services.Interfaces
{
    public interface IMessageConsumer
    {
        Task ConsumeAsync(CancellationToken cancellationToken);
    }
}
