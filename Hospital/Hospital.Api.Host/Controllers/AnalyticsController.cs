using Hospital.Application.Contracts;
using Hospital.Application.Contracts.Appointments;
using Hospital.Application.Contracts.Doctors;
using Hospital.Application.Contracts.Patients;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Host.Controllers;

/// <summary>
/// Controller for analytics operations in the hospital domain.
/// Provides endpoints for advanced queries like follow-up appointments,
/// doctors with experience, and patient statistics.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AnalyticsController(IAnalyticsService service, ILogger<AnalyticsController> logger) : Controller
{
    /// <summary>
    /// Retrieves all doctors who have at least 10 years of work experience.
    /// </summary>
    /// <returns>List of doctors with a minimum of 10 years of experience.</returns>
    [HttpGet("Doctors/Experienced")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<List<DoctorDto>>> GetDoctorsWithAtLeast10YearsExperience()
    {
        logger.LogInformation("{method} method of {controller} is called", nameof(GetDoctorsWithAtLeast10YearsExperience), GetType().Name);
        try
        {
            var res = await service.GetDoctorsWithAtLeast10YearsExperience();
            logger.LogInformation("{method} method of {controller} executed successfully", nameof(GetDoctorsWithAtLeast10YearsExperience), GetType().Name);
            return Ok(res);
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}", nameof(GetDoctorsWithAtLeast10YearsExperience), GetType().Name, ex);
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Retrieves all patients associated with a specific doctor.
    /// </summary>
    /// <param name="doctorId">Identifier of the doctor.</param>
    /// <returns>List of patients assigned to the given doctor.</returns>
    [HttpGet("Doctors/{doctorId}/Patients")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<List<PatientDto>>> GetPatientsByDoctorId(int doctorId)
    {
        logger.LogInformation("{method} method of {controller} is called with {doctorId} parameter", nameof(GetPatientsByDoctorId), GetType().Name, doctorId);
        try
        {
            var res = await service.GetPatientsByDoctorId(doctorId);
            if (res == null || !res.Any())
                return NotFound($"No patients found for doctor with ID {doctorId}");

            logger.LogInformation("{method} method of {controller} executed successfully", nameof(GetPatientsByDoctorId), GetType().Name);
            return Ok(res);
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}", nameof(GetPatientsByDoctorId), GetType().Name, ex);
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Retrieves all follow-up appointments that occurred in the last month.
    /// </summary>
    /// <returns>List of follow-up appointments from the previous month.</returns>
    [HttpGet("Appointments/FollowUps/LastMonth")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<List<AppointmentDto>>> GetFollowUpAppointmentsForLastMonth()
    {
        logger.LogInformation("{method} method of {controller} is called", nameof(GetFollowUpAppointmentsForLastMonth), GetType().Name);
        try
        {
            var res = await service.GetFollowUpAppointmentsForLastMonth();
            logger.LogInformation("{method} method of {controller} executed successfully", nameof(GetFollowUpAppointmentsForLastMonth), GetType().Name);
            return Ok(res);
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}", nameof(GetFollowUpAppointmentsForLastMonth), GetType().Name, ex);
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Retrieves all patients over 30 years old who have appointments with multiple doctors.
    /// </summary>
    /// <returns>List of patients over 30 with appointments with multiple doctors.</returns>
    [HttpGet("Patients/Over30/MultipleDoctors")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<List<PatientDto>>> GetPatientsOver30YearsWithMultipleDoctors()
    {
        logger.LogInformation("{method} method of {controller} is called", nameof(GetPatientsOver30YearsWithMultipleDoctors), GetType().Name);
        try
        {
            var res = await service.GetPatientsOver30YearsWithMultipleDoctors();
            logger.LogInformation("{method} method of {controller} executed successfully", nameof(GetPatientsOver30YearsWithMultipleDoctors), GetType().Name);
            return Ok(res);
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}", nameof(GetPatientsOver30YearsWithMultipleDoctors), GetType().Name, ex);
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Retrieves all appointments for a specific office (room) in the current month.
    /// </summary>
    /// <param name="officeNumber">The office or room number.</param>
    /// <returns>List of appointments in the specified office for the current month.</returns>
    [HttpGet("Appointments/ByOffice/{officeNumber}/CurrentMonth")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<List<AppointmentDto>>> GetAppointmentsByOfficeForCurrentMonth(int officeNumber)
    {
        logger.LogInformation("{method} method of {controller} is called with {officeNumber} parameter", nameof(GetAppointmentsByOfficeForCurrentMonth), GetType().Name, officeNumber);
        try
        {
            var res = await service.GetAppointmentsByOfficeForCurrentMonth(officeNumber);
            logger.LogInformation("{method} method of {controller} executed successfully", nameof(GetAppointmentsByOfficeForCurrentMonth), GetType().Name);
            return Ok(res);
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}", nameof(GetAppointmentsByOfficeForCurrentMonth), GetType().Name, ex);
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }
}