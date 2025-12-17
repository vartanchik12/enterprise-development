using Hospital.Application.Contracts.Appointments;
using RabbitMQ.Client;
using System.Text.Json;

namespace Hospital.Generator.RabbitMq.Host;

/// <summary>
/// RabbitMQ producer responsible for publishing batches of appointment contracts
/// (<see cref="AppointmentCreateUpdateDto"/>) to a configured queue.
/// </summary>
public class HospitalRabbitMqProducer(IConfiguration configuration, IConnection rabbitMqConnection, ILogger<HospitalRabbitMqProducer> logger)
{
    /// <summary>
    /// Target queue name used by the producer.
    /// </summary>
    private readonly string _queueName = configuration.GetSection("RabbitMq")["QueueName"] ?? throw new KeyNotFoundException("QueueName section of RabbitMq is missing");

    /// <summary>
    /// Publishes a batch of appointment contracts to the configured queue.
    /// </summary>
    /// <param name="batch">Batch of contracts to publish.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task that represents the asynchronous publish operation.</returns>
    public async Task SendAsync(IList<AppointmentCreateUpdateDto> batch, CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogInformation("Sending a batch of {count} contracts to {queue}", batch.Count, _queueName);

            var payload = JsonSerializer.SerializeToUtf8Bytes(batch);

            await using var channel = await rabbitMqConnection.CreateChannelAsync(cancellationToken: cancellationToken);

            await channel.QueueDeclareAsync(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null, cancellationToken: cancellationToken);

            await channel.BasicPublishAsync(exchange: string.Empty, routingKey: _queueName, mandatory: false, body: payload, cancellationToken: cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Exception occurred during sending a batch of {count} contracts to {queue}", batch.Count, _queueName);
        }
    }
}