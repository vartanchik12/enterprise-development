using AutoMapper;
using Hospital.Application.Contracts;
using Hospital.Application.Contracts.Patients;
using Hospital.Domain;
using Hospital.Domain.Model;

namespace Hospital.Application.Services;

/// <summary>
/// Application service for managing <see cref="Patient"/> entities.
/// Implements basic CRUD operations using a repository and AutoMapper.
/// </summary>
public class PatientService(IRepository<Patient, int> repository, IMapper mapper) : IApplicationService<PatientDto, PatientCreateUpdateDto, int>
{
    /// <summary>
    /// Creates a new patient.
    /// </summary>
    /// <param name="dto">DTO containing data for creation.</param>
    /// <returns>The created patient as DTO.</returns>
    public async Task<PatientDto> Create(PatientCreateUpdateDto dto)
    {
        var entity = mapper.Map<Patient>(dto);

        var result = await repository.Create(entity);

        return mapper.Map<PatientDto>(result);
    }

    /// <summary>
    /// Deletes a patient by its identifier.
    /// </summary>
    /// <param name="dtoId">Identifier of the patient.</param>
    /// <returns>True if deletion succeeded, false if not found.</returns>
    public async Task<bool> Delete(int dtoId)
    {
        return await repository.Delete(dtoId);
    }

    /// <summary>
    /// Retrieves a patient by its identifier.
    /// </summary>
    /// <param name="dtoId">Identifier of the patient.</param>
    /// <returns>The patient DTO, or throws if not found.</returns>
    public async Task<PatientDto?> Get(int dtoId)
    {
        var entity = await repository.Read(dtoId) ?? throw new KeyNotFoundException($"Entity with Id {dtoId} not found");

        return mapper.Map<PatientDto>(entity);
    }

    /// <summary>
    /// Retrieves all patients.
    /// </summary>
    /// <returns>List of all patient DTOs.</returns>
    public async Task<IList<PatientDto>> GetAll()
    {
        return mapper.Map<List<PatientDto>>(await repository.ReadAll());
    }

    /// <summary>
    /// Updates an existing patient.
    /// </summary>
    /// <param name="dto">DTO containing updated data.</param>
    /// <param name="dtoId">Identifier of the patient to update.</param>
    /// <returns>The updated patient DTO.</returns>
    public async Task<PatientDto> Update(PatientCreateUpdateDto dto, int dtoId)
    {
        var entity = await repository.Read(dtoId) ?? throw new KeyNotFoundException($"Entity with Id {dtoId} not found");

        mapper.Map(dto, entity);

        var result = await repository.Update(entity);

        return mapper.Map<PatientDto>(result);
    }
}