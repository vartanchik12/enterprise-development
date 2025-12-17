using Hospital.Application.Contracts.Appointments;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text.Json;

namespace Hospital.Infrastructure.RabbitMq;

/// <summary>
/// RabbitMQ consumer for processing appointment contracts from a configured queue.
/// Deserializes incoming messages into <see cref="AppointmentCreateUpdateDto"/> list and creates appointments via <see cref="IAppointmentService"/>.
/// </summary>
public class HospitalRabbitMqConsumer(IConnection connection, IServiceScopeFactory scopeFactory, IConfiguration configuration, ILogger<HospitalRabbitMqConsumer> logger) : BackgroundService
{
    /// <summary>
    /// Target queue name used by the consumer.
    /// </summary>
    private readonly string _queueName = configuration.GetSection("RabbitMq")["QueueName"] ?? throw new KeyNotFoundException("QueueName section of RabbitMq is missing");

    /// <summary>
    /// Starts the background worker that declares the queue and begins consuming messages.
    /// </summary>
    /// <param name="stoppingToken">Cancellation token used to stop the worker.</param>
    /// <returns>A task that represents the lifetime of the background worker.</returns>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("Establishing channel to queue {queue}", _queueName);

        var channel = await connection.CreateChannelAsync(cancellationToken: stoppingToken);
        await channel.QueueDeclareAsync(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null, cancellationToken: stoppingToken);

        logger.LogInformation("Began listening to queue {queue}", _queueName);

        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.ReceivedAsync += async (_, ea) => await ReceiveMessage(ea, stoppingToken);

        await channel.BasicConsumeAsync(queue: _queueName, autoAck: true, consumer: consumer, cancellationToken: stoppingToken);
    }

    /// <summary>
    /// Processes a single message delivery from RabbitMQ.
    /// Attempts to deserialize message body into a list of appointment contracts and creates appointments.
    /// </summary>
    /// <param name="args">RabbitMQ delivery payload and metadata.</param>
    /// <param name="stoppingToken">Cancellation token used to stop processing.</param>
    /// <returns>A task that represents the asynchronous processing operation.</returns>
    private async Task ReceiveMessage(BasicDeliverEventArgs args, CancellationToken stoppingToken)
    {
        logger.LogInformation("Received a message from queue {queue}", _queueName);

        try
        {
            stoppingToken.ThrowIfCancellationRequested();

            var contracts = JsonSerializer.Deserialize<List<AppointmentCreateUpdateDto>>(args.Body.Span)
                ?? throw new FormatException("Unable to parse contracts from message body");

            using var scope = scopeFactory.CreateScope();
            var appointmentService = scope.ServiceProvider.GetRequiredService<IAppointmentService>();

            foreach (var contract in contracts)
            {
                try
                {
                    await appointmentService.Create(contract);
                }
                catch (KeyNotFoundException ex)
                {
                    logger.LogWarning(ex, "Skipping contract due to missing related entity in {queue} with PatientId {patientId} and DoctorId {doctorId}", _queueName, contract.PatientId, contract.DoctorId);
                }
            }
        }
        catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("Message processing cancelled for queue {queue}", _queueName);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Exception occurred during receiving contracts from {queue}", _queueName);
        }
    }
}