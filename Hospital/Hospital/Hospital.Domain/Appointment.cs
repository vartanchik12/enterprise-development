namespace Hospital.Domain;

/// <summary>
/// Represents a medical appointment.
/// </summary>
public class Appointment
{
    /// <summary>
    /// Unique identifier for the appointment.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Date and time of the appointment.
    /// </summary>
    public required DateTime AppointmentTime { get; set; }

    /// <summary>
    /// Room number where the appointment takes place.
    /// </summary>
    public required int RoomNumber { get; set; }

    /// <summary>
    /// Indicates if this is a follow-up appointment.
    /// </summary>
    public required bool IsFollow { get; set; }

    /// <summary>
    /// Identifier of the patient for the appointment.
    /// </summary>
    public required int PatientId { get; set; }

    /// <summary>
    /// Identifier of the doctor for the appointment.
    /// </summary>
    public required int DoctorId { get; set; }
}