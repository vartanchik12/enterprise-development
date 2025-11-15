namespace Hospital.Application.Contracts.Doctors;

/// <summary>
/// DTO for creating or updating a doctor's information.
/// </summary>
/// <param name="Passport">The passport number of the doctor.</param>
/// <param name="FullName">The full name of the doctor.</param>
/// <param name="BirthDate">The birth date of the doctor.</param>
/// <param name="SpecializationId">The identifier of the doctor's specialization.</param>
/// <param name="WorkExperience">The work experience in years (optional).</param>
public record DoctorCreateUpdateDto(string Passport, string FullName, DateOnly BirthDate, int SpecializationId, int? WorkExperience);