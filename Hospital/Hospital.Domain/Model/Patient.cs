namespace Hospital.Domain.Model;

/// <summary>
/// Represents a patient in the hospital system.
/// </summary>
public class Patient
{
    /// <summary>
    /// Unique identifier for the patient.
    /// </summary>
    public required int Id { get; set; }

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
    public required Sex Sex { get; set; }

    /// <summary>
    /// Date of birth of the patient.
    /// </summary>
    public required DateOnly BirthDate { get; set; }

    /// <summary>
    /// Residential address of the patient.
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// Blood type of the patient.
    /// </summary>
    public BloodType? BloodType { get; set; }

    /// <summary>
    /// Rh factor of the patient's blood.
    /// </summary>
    public RHFactor? RHFactor { get; set; }

    /// <summary>
    /// Contact phone number of the patient.
    /// </summary>
    public string? PhoneNumber { get; set; }
}