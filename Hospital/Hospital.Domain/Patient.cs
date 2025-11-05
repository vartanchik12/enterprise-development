namespace Hospital.Domain;

/// <summary>
/// Represents a patient in the hospital system.
/// </summary>
public class Patient
{
    /// <summary>
    /// Unique identifier for the patient.
    /// </summary>
    public required int ID { get; set; }

    /// <summary>
    /// Passport number of the patient.
    /// </summary>
    public required string Passport { get; set; }

    /// <summary>
    /// Full name of the patient.
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// Gender of the patient.
    /// </summary>
    public required Sex? Sex { get; set; }

    /// <summary>
    /// Date of birth of the patient.
    /// </summary>
    public required DateTime BirthDate { get; set; }

    /// <summary>
    /// Residential address of the patient.
    /// </summary>
    public required string Address { get; set; }

    /// <summary>
    /// Blood type of the patient.
    /// </summary>
    public required BloodType? BloodType { get; set; }

    /// <summary>
    /// Rh factor of the patient's blood.
    /// </summary>
    public required RHFactor? RHFactor { get; set; }

    /// <summary>
    /// Contact phone number of the patient.
    /// </summary>
    public required string PhoneNumber { get; set; }
}