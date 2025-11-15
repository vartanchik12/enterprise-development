namespace Hospital.Domain.Model;

/// <summary>
/// Represents a medical doctor.
/// </summary>
public class Doctor
{
    /// <summary>
    /// Unique identifier for the doctor.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Passport number of the doctor.
    /// </summary>
    public required string Passport { get; set; }

    /// <summary>
    /// Full name of the doctor.
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// Date of birth of the doctor.
    /// </summary>
    public required DateOnly BirthDate { get; set; }

    /// <summary>
    /// Medical specialization of the doctor.
    /// </summary>
    public required Specialization Specialization { get; set; }

    /// <summary>
    /// Years of work experience.
    /// </summary>
    public int? WorkExperience { get; set; }
}