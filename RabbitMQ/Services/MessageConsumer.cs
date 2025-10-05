namespace TheLaboratory.Services
{
    public class MessageConsumer : BackgroundService, IMessageConsumer
    {
        private readonly ILogger<MessageConsumer> _logger;
        private readonly RabbitMqOptions _options;
        private IConnection? _connection;
        private IChannel? _channel;

        public MessageConsumer(ILogger<MessageConsumer> logger, IOptions<RabbitMqOptions> options)
        {
            _logger = logger;
            _options = options.Value;
        }
        private async Task InitializeAsync()
        {
            var factory = new ConnectionFactory
            {
                HostName = _options.HostName,
                UserName = _options.UserName,
                Password = _options.Password
            };

            _connection = await factory.CreateConnectionAsync();

            _channel = await _connection.CreateChannelAsync();

            await _channel.QueueDeclareAsync(
                queue: "OrderCreatedMessage",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );
        }

        public async Task ConsumeAsync(CancellationToken cancellationToken)
        {
            if (_channel is null)
                await InitializeAsync();

            var consumer = new AsyncEventingBasicConsumer(_channel!);

            consumer.ReceivedAsync += async (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();

                var message = Encoding.UTF8.GetString(body);

                _logger.LogInformation($"[CONSUMER] Received message: {message}");

                try
                {
                    var orderMessage = JsonSerializer.Deserialize<OrderCreatedMessage>(message);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error processing message");
                }


                await Task.Yield();
            };
            await _channel!.BasicConsumeAsync(
                queue: "OrderCreatedMessage",
                autoAck: true,
                consumer: consumer
            );
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await ConsumeAsync(stoppingToken);
        }
        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            if (_channel is not null)
                await _channel.CloseAsync();

            if (_connection is not null)
                await _connection.CloseAsync();

            await base.StopAsync(cancellationToken);
        }
    }
}
