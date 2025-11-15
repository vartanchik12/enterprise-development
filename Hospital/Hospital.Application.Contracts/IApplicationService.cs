namespace Hospital.Application.Contracts;

/// <summary>
/// Interface for application services handling CRUD operations.
/// </summary>
/// <typeparam name="TDto">DTO used for Get requests.</typeparam>
/// <typeparam name="TCreateUpdateDto">DTO used for Post/Put requests.</typeparam>
/// <typeparam name="TKey">Type of the DTO identifier.</typeparam>
public interface IApplicationService<TDto, TCreateUpdateDto, TKey>
    where TDto : class
    where TCreateUpdateDto : class
    where TKey : struct
{
    /// <summary>
    /// Creates a new DTO.
    /// </summary>
    /// <param name="dto">The DTO to create.</param>
    /// <returns>The created DTO.</returns>
    public Task<TDto> Create(TCreateUpdateDto dto);

    /// <summary>
    /// Retrieves a DTO by its identifier.
    /// </summary>
    /// <param name="dtoId">The identifier of the DTO.</param>
    /// <returns>The DTO if found; otherwise null.</returns>
    public Task<TDto?> Get(TKey dtoId);

    /// <summary>
    /// Retrieves all DTOs.
    /// </summary>
    /// <returns>A list of all DTOs.</returns>
    public Task<IList<TDto>> GetAll();

    /// <summary>
    /// Updates an existing DTO.
    /// </summary>
    /// <param name="dto">The DTO with updated data.</param>
    /// <param name="dtoId">The identifier of the DTO to update.</param>
    /// <returns>The updated DTO.</returns>
    public Task<TDto> Update(TCreateUpdateDto dto, TKey dtoId);

    /// <summary>
    /// Deletes a DTO by its identifier.
    /// </summary>
    /// <param name="dtoId">The identifier of the DTO to delete.</param>
    /// <returns>true if the DTO was deleted; otherwise false.</returns>
    public Task<bool> Delete(TKey dtoId);
}