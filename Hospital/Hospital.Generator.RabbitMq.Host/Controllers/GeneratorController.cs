using Hospital.Application.Contracts.Appointments;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Generator.RabbitMq.Host.Controllers;

/// <summary>
/// API controller that generates appointment contracts and publishes them to RabbitMQ in batches.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class GeneratorController(ILogger<GeneratorController> logger, HospitalRabbitMqProducer producerService) : ControllerBase
{
    /// <summary>
    /// Generates appointment contracts, sends them to RabbitMQ in batches, and returns the generated payload.
    /// </summary>
    /// <param name="batchSize">Number of contracts per batch to generate and publish.</param>
    /// <param name="payloadLimit">Total number of contracts to generate.</param>
    /// <param name="waitTime">Delay between batches in seconds.</param>
    /// <returns>
    /// 200 OK with the list of generated contracts; 400 Bad Request for invalid input; otherwise 500 Internal Server Error.
    /// </returns>
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<List<AppointmentCreateUpdateDto>>> Get([FromQuery] int batchSize, [FromQuery] int payloadLimit, [FromQuery] int waitTime)
    {
        if (batchSize <= 0)
            return BadRequest("batchSize must be greater than 0");

        if (payloadLimit <= 0)
            return BadRequest("payloadLimit must be greater than 0");

        if (waitTime < 0)
            return BadRequest("waitTime must be greater than or equal to 0");

        logger.LogInformation("Generating {limit} contracts via {batchSize} batches and {waitTime}s delay", payloadLimit, batchSize, waitTime);

        try
        {
            var list = new List<AppointmentCreateUpdateDto>(payloadLimit);
            var remaining = payloadLimit;

            while (remaining > 0)
            {
                var currentBatchSize = Math.Min(batchSize, remaining);
                var batch = AppointmentGenerator.GenerateContracts(currentBatchSize);

                await producerService.SendAsync(batch);

                logger.LogInformation("Batch of {batchSize} items has been sent", currentBatchSize);

                remaining -= currentBatchSize;
                list.AddRange(batch);

                if (remaining > 0 && waitTime > 0)
                    await Task.Delay(TimeSpan.FromSeconds(waitTime));
            }

            logger.LogInformation("{method} method of {controller} executed successfully", nameof(Get), GetType().Name);
            return Ok(list);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An exception happened during {method} method of {controller}", nameof(Get), GetType().Name);
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }
}