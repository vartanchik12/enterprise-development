namespace Hospital.Application.Contracts.Appointments;

/// <summary>
/// DTO for creating or updating an appointment.
/// </summary>
/// <param name="AppointmentTime">The date and time of the appointment.</param>
/// <param name="RoomNumber">The room number where the appointment takes place.</param>
/// <param name="IsFollow">Indicates whether it is a follow-up appointment.</param>
/// <param name="PatientId">The identifier of the patient.</param>
/// <param name="DoctorId">The identifier of the doctor.</param>
public record AppointmentCreateUpdateDto(DateTime AppointmentTime, int RoomNumber, bool IsFollow, int PatientId, int DoctorId);