namespace Hospital.Domain;

/// <summary>
/// Represents a medical doctor.
/// </summary>
public class Doctor
{
    /// <summary>
    /// Unique identifier for the doctor.
    /// </summary>
    public required int ID { get; set; }

    /// <summary>
    /// Passport number of the doctor.
    /// </summary>
    public required string Passport { get; set; }

    /// <summary>
    /// Full name of the doctor.
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// Year of birth of the doctor.
    /// </summary>
    public required int BirthYear { get; set; }

    /// <summary>
    /// Medical specialization of the doctor.
    /// </summary>
    public required Specialization? Specialization { get; set; }

    /// <summary>
    /// Years of work experience.
    /// </summary>
    public required int WorkExperience { get; set; }
}