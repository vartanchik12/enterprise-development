namespace Hospital.Application.Contracts.Specializations;

/// <summary>
/// DTO for creating or updating a doctor's specialization.
/// </summary>
/// <param name="Name">The name of the specialization.</param>
public record SpecializationCreateUpdateDto(string Name);