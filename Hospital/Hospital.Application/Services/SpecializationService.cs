using AutoMapper;
using Hospital.Application.Contracts;
using Hospital.Application.Contracts.Specializations;
using Hospital.Domain;
using Hospital.Domain.Model;

namespace Hospital.Application.Services;

/// <summary>
/// Application service for managing <see cref="Specialization"/> entities.
/// Implements basic CRUD operations using a repository and AutoMapper.
/// </summary>
public class SpecializationService(IRepository<Specialization, int> repository, IMapper mapper) : IApplicationService<SpecializationDto, SpecializationCreateUpdateDto, int>
{
    /// <summary>
    /// Creates a new specialization.
    /// </summary>
    /// <param name="dto">DTO containing data for creation.</param>
    /// <returns>The created specialization as DTO.</returns>
    public async Task<SpecializationDto> Create(SpecializationCreateUpdateDto dto)
    {
        var entity = mapper.Map<Specialization>(dto);

        var result = await repository.Create(entity);

        return mapper.Map<SpecializationDto>(result);
    }

    /// <summary>
    /// Deletes a specialization by its identifier.
    /// </summary>
    /// <param name="dtoId">Identifier of the specialization.</param>
    /// <returns>True if deletion succeeded, false if not found.</returns>
    public async Task<bool> Delete(int dtoId)
    {
        return await repository.Delete(dtoId);
    }

    /// <summary>
    /// Retrieves a specialization by its identifier.
    /// </summary>
    /// <param name="dtoId">Identifier of the specialization.</param>
    /// <returns>The specialization DTO, or throws if not found.</returns>
    public async Task<SpecializationDto?> Get(int dtoId)
    {
        var entity = await repository.Read(dtoId) ?? throw new KeyNotFoundException($"Entity with Id {dtoId} not found");

        return mapper.Map<SpecializationDto>(entity);
    }

    /// <summary>
    /// Retrieves all specializations.
    /// </summary>
    /// <returns>List of all specialization DTOs.</returns>
    public async Task<IList<SpecializationDto>> GetAll()
    {
        return mapper.Map<List<SpecializationDto>>(await repository.ReadAll());
    }

    /// <summary>
    /// Updates an existing specialization.
    /// </summary>
    /// <param name="dto">DTO containing updated data.</param>
    /// <param name="dtoId">Identifier of the specialization to update.</param>
    public async Task<SpecializationDto> Update(SpecializationCreateUpdateDto dto, int dtoId)
    {
        var entity = await repository.Read(dtoId) ?? throw new KeyNotFoundException($"Entity with Id {dtoId} not found");

        mapper.Map(dto, entity);

        var result = await repository.Update(entity);

        return mapper.Map<SpecializationDto>(result);
    }
}