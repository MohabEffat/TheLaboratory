using GrpcService;
using Microsoft.Extensions.DependencyInjection;

namespace GrpcClient
{
    public static class ServiceCollectionExtension
    {
        public static void AddGrpcClient(this IServiceCollection services)
        {
            services.AddGrpcClient<Greeter.GreeterClient>(client =>
            {
                client.Address = new Uri("https://localhost:7227");
            });

            services.AddScoped<IGreeterGrpcService, GreeterService>();
        }
    }
}
