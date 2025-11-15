using Hospital.Application.Contracts.Appointments;
using Hospital.Application.Contracts.Doctors;
using Hospital.Application.Contracts.Patients;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Host.Controllers;

/// <summary>
/// Controller for managing appointments.
/// Inherits CRUD operations from CrudControllerBase/>.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AppointmentController(IAppointmentService service, ILogger<AppointmentController> logger) 
    : CrudControllerBase<AppointmentDto, AppointmentCreateUpdateDto, int>(service, logger)
{
    /// <summary>
    /// Retrieves the doctor associated with a specific appointment.
    /// </summary>
    /// <param name="id">Identifier of the appointment.</param>
    /// <returns>The doctor DTO if found; otherwise NotFound.</returns>
    [HttpGet("{id}/Doctor")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<DoctorDto>> GetDoctor(int id)
    {
        logger.LogInformation("{method} method of {controller} is called with {id} parameter", nameof(Get), GetType().Name, id);
        try
        {
            var res = await service.GetDoctor(id);
            logger.LogInformation("{method} method of {controller} executed successfully", nameof(Get), GetType().Name);
            return Ok(res);
        }
        catch (KeyNotFoundException ex)
        {
            logger.LogWarning("A not found exception happened during {method} method of {controller}: {@exception}", nameof(Get), GetType().Name, ex);
            return NotFound($"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}", nameof(Get), GetType().Name, ex);
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Retrieves the patient associated with a specific appointment.
    /// </summary>
    /// <param name="id">Identifier of the appointment.</param>
    /// <returns>The patient DTO if found; otherwise NotFound.</returns>
    [HttpGet("{id}/Patient")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<PatientDto>> GetPatient(int id)
    {
        logger.LogInformation("{method} method of {controller} is called with {id} parameter", nameof(Get), GetType().Name, id);
        try
        {
            var res = await service.GetPatient(id);
            logger.LogInformation("{method} method of {controller} executed successfully", nameof(Get), GetType().Name);
            return Ok(res);
        }
        catch (KeyNotFoundException ex)
        {
            logger.LogWarning("A not found exception happened during {method} method of {controller}: {@exception}", nameof(Get), GetType().Name, ex);
            return NotFound($"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}", nameof(Get), GetType().Name, ex);
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }
}