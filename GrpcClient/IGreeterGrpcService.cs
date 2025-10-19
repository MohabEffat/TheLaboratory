using GrpcService;

namespace GrpcClient
{
    public interface IGreeterGrpcService  
    {
        Task<string> SayHelloAsync(string name, CancellationToken cancellationToken);
    }

    public class GreeterService : IGreeterGrpcService
    {
        private readonly Greeter.GreeterClient _greeterClient;
        public GreeterService(Greeter.GreeterClient greeterClient)
        {
            _greeterClient = greeterClient;
        }
        public async Task<string> SayHelloAsync(string name, CancellationToken cancellationToken)
        {
            var request = new HelloRequest { Name = name };

            var response = await _greeterClient.SayHelloAsync(request, cancellationToken: cancellationToken);

            return response.Message;
        }

    }
}
