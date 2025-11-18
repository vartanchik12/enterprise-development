using Hospital.Application.Contracts.Appointments;
using Hospital.Application.Contracts.Doctors;
using Hospital.Application.Contracts.Specializations;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Host.Controllers;

/// <summary>
/// Controller for managing doctors and retrieving related data.
/// Inherits CRUD operations from CrudControllerBase.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DoctorController(IDoctorService service, IAppointmentService appointmentService, ILogger<DoctorController> logger)
    : CrudControllerBase<DoctorDto, DoctorCreateUpdateDto, int>(service, logger)
{
    /// <summary>
    /// Retrieves the specialization associated with a specific doctor.
    /// </summary>
    /// <param name="id">Identifier of the doctor.</param>
    /// <returns>The specialization DTO if found; otherwise NotFound.</returns>
    [HttpGet("{id}/Specialization")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<SpecializationDto>> GetSpecialization(int id)
    {
        logger.LogInformation("{method} method of {controller} is called with {id} parameter", nameof(GetSpecialization), GetType().Name, id);
        try
        {
            var res = await service.GetSpecialization(id);
            logger.LogInformation("{method} method of {controller} executed successfully", nameof(GetSpecialization), GetType().Name);
            return Ok(res);
        }
        catch (KeyNotFoundException ex)
        {
            logger.LogWarning("A not found exception happened during {method} method of {controller}: {@exception}", nameof(GetSpecialization), GetType().Name, ex);
            return NotFound($"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}", nameof(GetSpecialization), GetType().Name, ex);
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Retrieves all appointments associated with a specific doctor.
    /// </summary>
    /// <param name="id">Identifier of the doctor.</param>
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
            var res = await appointmentService.GetAppointmentsByDoctorId(id);
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