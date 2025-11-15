namespace Hospital.Domain;

/// <summary>
/// Repository interface for CRUD operations.
/// </summary>
/// <typeparam name="TEntity">
/// The type of entity for which the collection access is abstracted.
/// </typeparam>
/// <typeparam name="TKey">
/// The type of the entity identifier.
/// </typeparam>
public interface IRepository<TEntity, TKey>
{
    /// <summary>
    /// Creates a new entity.
    /// </summary>
    /// <param name="entity">The entity to create.</param>
    public Task<TEntity> Create(TEntity entity);

    /// <summary>
    /// Retrieves an entity by its identifier.
    /// </summary>
    /// <param name="entityId">The entity identifier.</param>
    /// <returns>The entity, or null if not found.</returns>
    public Task<TEntity?> Read(TKey entityId);

    /// <summary>
    /// Retrieves all entities.
    /// </summary>
    public Task<IList<TEntity>> ReadAll();

    /// <summary>
    /// Updates an existing entity.
    /// </summary>
    /// <param name="entity">The modified entity.</param>
    public Task<TEntity> Update(TEntity entity);

    /// <summary>
    /// Deletes an entity by its identifier.
    /// </summary>
    /// <param name="entityId">The entity identifier.</param>
    public Task<bool> Delete(TKey entityId);
}