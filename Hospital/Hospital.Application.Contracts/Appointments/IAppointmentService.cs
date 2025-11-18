namespace Hospital.Application.Contracts.Appointments;

/// <summary>
/// Application service interface for managing appointments.
/// Inherits basic CRUD operations from IApplicationService/>.
/// </summary>
public interface IAppointmentService : IApplicationService<AppointmentDto, AppointmentCreateUpdateDto, int>
{
    /// <summary>
    /// Retrieves all appointments for the specified doctor.
    /// </summary>
    /// <param name="doctorId">Identifier of the doctor.</param>
    /// <returns>List of appointments for the doctor.</returns>
    public Task<IList<AppointmentDto>> GetAppointmentsByDoctorId(int doctorId);

    /// <summary>
    /// Retrieves all appointments for the specified patient.
    /// </summary>
    /// <param name="patientId">Identifier of the patient.</param>
    /// <returns>List of appointments for the patient.</returns>
    public Task<IList<AppointmentDto>> GetAppointmentsByPatientId(int patientId);
}