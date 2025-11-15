namespace Hospital.Application.Contracts.Doctors;

/// <summary>
/// DTO representing a doctor.
/// </summary>
/// <param name="Id">The identifier of the doctor.</param>
/// <param name="Passport">The passport number of the doctor.</param>
/// <param name="FullName">The full name of the doctor.</param>
/// <param name="BirthDate">The birth date of the doctor.</param>
/// <param name="WorkExperience">The work experience in years (optional).</param>
public record DoctorDto(int Id, string Passport, string FullName, DateOnly BirthDate, int? WorkExperience);