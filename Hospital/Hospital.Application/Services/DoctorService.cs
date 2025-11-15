using AutoMapper;
using Hospital.Application.Contracts.Doctors;
using Hospital.Application.Contracts.Specializations;
using Hospital.Domain;
using Hospital.Domain.Model;

namespace Hospital.Application.Services;

/// <summary>
/// Application service for managing <see cref="Doctor"/> entities.
/// Implements basic CRUD operations and provides access to associated specializations.
/// </summary>
public class DoctorService(IRepository<Doctor, int> repository, IRepository<Specialization, int> specializationRepository, IMapper mapper) : IDoctorService
{
    /// <summary>
    /// Creates a new doctor.
    /// </summary>
    /// <param name="dto">DTO containing data for creation.</param>
    /// <returns>The created doctor as DTO.</returns>
    public async Task<DoctorDto> Create(DoctorCreateUpdateDto dto)
    {
        var entity = mapper.Map<Doctor>(dto);

        entity.Specialization = await specializationRepository.Read(dto.SpecializationId) 
            ?? throw new KeyNotFoundException($"Specialization with Id {dto.SpecializationId} not found");

        var result = await repository.Create(entity);

        return mapper.Map<DoctorDto>(result);
    }

    /// <summary>
    /// Deletes a doctor by its identifier.
    /// </summary>
    /// <param name="dtoId">Identifier of the doctor.</param>
    /// <returns>True if deletion succeeded, false if not found.</returns>
    public async Task<bool> Delete(int dtoId)
    {
        return await repository.Delete(dtoId);
    }

    /// <summary>
    /// Retrieves a doctor by its identifier.
    /// </summary>
    /// <param name="dtoId">Identifier of the doctor.</param>
    /// <returns>The doctor DTO, or throws if not found.</returns>
    public async Task<DoctorDto?> Get(int dtoId)
    {
        var entity = await repository.Read(dtoId) ?? throw new KeyNotFoundException($"Entity with Id {dtoId} not found");

        return mapper.Map<DoctorDto>(entity);
    }

    /// <summary>
    /// Retrieves all doctors.
    /// </summary>
    /// <returns>List of all doctor DTOs.</returns>
    public async Task<IList<DoctorDto>> GetAll()
    {
        return mapper.Map<List<DoctorDto>>(await repository.ReadAll());
    }

    /// <summary>
    /// Retrieves the specialization associated with a doctor.
    /// </summary>
    /// <param name="doctorId">Identifier of the doctor.</param>
    /// <returns>The specialization DTO of the doctor.</returns>
    public async Task<SpecializationDto> GetSpecialization(int doctorId)
    {
        var entity = await repository.Read(doctorId)
                     ?? throw new KeyNotFoundException($"Entity with Id {doctorId} not found");

        return mapper.Map<SpecializationDto>(entity.Specialization);
    }

    /// <summary>
    /// Updates an existing doctor.
    /// </summary>
    /// <param name="dto">DTO containing updated data.</param>
    /// <param name="dtoId">Identifier of the doctor to update.</param>
    /// <returns>The updated doctor DTO.</returns>
    public async Task<DoctorDto> Update(DoctorCreateUpdateDto dto, int dtoId)
    {
        var entity = await repository.Read(dtoId) ?? throw new KeyNotFoundException($"Entity with Id {dtoId} not found");

        mapper.Map(dto, entity);

        var result = await repository.Update(entity);

        return mapper.Map<DoctorDto>(result);
    }
}