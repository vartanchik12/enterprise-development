namespace Hospital.Application.Contracts.Specializations;

/// <summary>
/// DTO representing a doctor's specialization.
/// </summary>
/// <param name="Id">The identifier of the specialization.</param>
/// <param name="Name">The name of the specialization.</param>
public record SpecializationDto(int Id, string Name);