using Hospital.Application.Contracts.Doctors;
using Hospital.Application.Contracts.Patients;

namespace Hospital.Application.Contracts.Appointments;

/// <summary>
/// Application service interface for managing appointments.
/// Inherits basic CRUD operations from IApplicationService/>.
/// </summary>
public interface IAppointmentService : IApplicationService<AppointmentDto, AppointmentCreateUpdateDto, int>
{
    /// <summary>
    /// Retrieves the doctor associated with the specified appointment.
    /// </summary>
    /// <param name="appointmentId">The identifier of the appointment.</param>
    /// <returns>The doctor for the appointment.</returns>
    public Task<DoctorDto> GetDoctor(int appointmentId);

    /// <summary>
    /// Retrieves the patient associated with the specified appointment.
    /// </summary>
    /// <param name="appointmentId">The identifier of the appointment.</param>
    /// <returns>The patient for the appointment.</returns>
    public Task<PatientDto> GetPatient(int appointmentId);
}