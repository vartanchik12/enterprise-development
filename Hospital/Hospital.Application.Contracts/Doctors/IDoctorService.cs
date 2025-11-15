using Hospital.Application.Contracts.Specializations;

namespace Hospital.Application.Contracts.Doctors;

/// <summary>
/// Application service interface for managing doctors.
/// Inherits basic CRUD operations from IApplicationService/>.
/// </summary>
public interface IDoctorService : IApplicationService<DoctorDto, DoctorCreateUpdateDto, int>
{
    /// <summary>
    /// Retrieves the specialization associated with the specified doctor.
    /// </summary>
    /// <param name="doctorId">The identifier of the doctor.</param>
    /// <returns>The specialization of the doctor.</returns>
    public Task<SpecializationDto> GetSpecialization(int doctorId);
}