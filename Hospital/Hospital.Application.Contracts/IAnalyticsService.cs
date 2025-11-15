using Hospital.Application.Contracts.Appointments;
using Hospital.Application.Contracts.Doctors;
using Hospital.Application.Contracts.Patients;

namespace Hospital.Application.Contracts;

/// <summary>
/// Provides analytical operations and queries for hospital data.
/// Includes methods for retrieving doctors, patients, and appointments based on specific criteria.
/// </summary>
public interface IAnalyticsService
{
    /// <summary>
    /// Retrieves all doctors who have at least 10 years of work experience.
    /// </summary>
    /// <returns>List of doctors with a minimum of 10 years of experience.</returns>
    public Task<IList<DoctorDto>> GetDoctorsWithAtLeast10YearsExperience();

    /// <summary>
    /// Retrieves all patients associated with a specific doctor.
    /// </summary>
    /// <param name="doctorId">Identifier of the doctor.</param>
    /// <returns>List of patients assigned to the given doctor.</returns>
    public Task<IList<PatientDto>> GetPatientsByDoctorId(int doctorId);

    /// <summary>
    /// Retrieves all follow-up appointments that occurred in the last month.
    /// </summary>
    /// <returns>List of follow-up appointments from the previous month.</returns>
    public Task<IList<AppointmentDto>> GetFollowUpAppointmentsForLastMonth();

    /// <summary>
    /// Retrieves all patients over 30 years old who have appointments with multiple doctors.
    /// </summary>
    /// <returns>List of patients over 30 with appointments with multiple doctors.</returns>
    public Task<IList<PatientDto>> GetPatientsOver30YearsWithMultipleDoctors();

    /// <summary>
    /// Retrieves all appointments for a specific office (room) in the current month.
    /// </summary>
    /// <param name="officeNumber">The office or room number.</param>
    /// <returns>List of appointments in the specified office for the current month.</returns>
    public Task<IList<AppointmentDto>> GetAppointmentsByOfficeForCurrentMonth(int officeNumber);
}