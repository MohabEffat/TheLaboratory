var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RabbitMqOptions>(builder.Configuration.GetSection("RabbitMQ"));

builder.Services.AddSingleton<IMessageProducer, MessageProducer>();
builder.Services.AddHostedService<MessageConsumer>();

var app = builder.Build();

app.MapPost("/orders", async (OrderCreatedMessage order, IMessageProducer producer) =>
{
    OrderStore.Orders.Add(order);

    await producer.PublishAsync(order);

    return Results.Ok(new { Message = "Message Published To RabbitMQ!" });
});

app.Run();
