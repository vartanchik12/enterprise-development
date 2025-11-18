using Hospital.Application.Contracts;
using Hospital.Application.Contracts.Appointments;
using Hospital.Application.Contracts.Patients;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Host.Controllers;

/// <summary>
/// Controller for managing patients and retrieving their appointments.
/// Inherits CRUD operations from CrudControllerBase.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PatientController(IApplicationService<PatientDto, PatientCreateUpdateDto, int> service, IAppointmentService appointmentService, ILogger<PatientController> logger)
    : CrudControllerBase<PatientDto, PatientCreateUpdateDto, int>(service, logger)
{
    /// <summary>
    /// Retrieves all appointments associated with a specific patient.
    /// </summary>
    /// <param name="id">Identifier of the patient.</param>
    /// <returns>List of appointment DTOs.</returns>
    [HttpGet("{id}/Appointments")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<AppointmentDto>> GetAppointments(int id)
    {
        logger.LogInformation("{method} method of {controller} is called with {id} parameter", nameof(GetAppointments), GetType().Name, id);
        try
        {
            var res = await appointmentService.GetAppointmentsByPatientId(id);
            logger.LogInformation("{method} method of {controller} executed successfully", nameof(GetAppointments), GetType().Name);
            return Ok(res);
        }
        catch (KeyNotFoundException ex)
        {
            logger.LogWarning("A not found exception happened during {method} method of {controller}: {@exception}", nameof(GetAppointments), GetType().Name, ex);
            return NotFound($"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}", nameof(GetAppointments), GetType().Name, ex);
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }
}