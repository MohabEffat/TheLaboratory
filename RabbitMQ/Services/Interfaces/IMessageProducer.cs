namespace TheLaboratory.Services.Interfaces
{
    public interface IMessageProducer
    {
        Task PublishAsync<T>(T message);
    }
}
