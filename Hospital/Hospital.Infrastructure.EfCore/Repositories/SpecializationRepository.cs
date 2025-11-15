using Hospital.Domain;
using Hospital.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.EfCore.Repositories;

/// <summary>
/// Repository for managing <see cref="Specialization"/> entities.
/// Provides basic CRUD operations using <see cref="HospitalDbContext"/>.
/// </summary>
public class SpecializationRepository(HospitalDbContext context) : IRepository<Specialization, int>
{
    /// <summary>
    /// Creates a new <see cref="Specialization"/> in the database.
    /// </summary>
    /// <param name="entity">Specialization to create.</param>
    /// <returns>The created specialization.</returns>
    public async Task<Specialization> Create(Specialization entity)
    {
        var result = await context.Specializations.AddAsync(entity);

        await context.SaveChangesAsync();

        return result.Entity;
    }

    /// <summary>
    /// Deletes a specialization by its identifier.
    /// </summary>
    /// <param name="entityId">Identifier of the specialization.</param>
    /// <returns>true if the specialization was found and deleted; otherwise false.</returns>
    public async Task<bool> Delete(int entityId)
    {
        var entity = await context.Specializations.FirstOrDefaultAsync(e => e.Id == entityId);

        if (entity == null)
            return false;

        context.Specializations.Remove(entity);

        await context.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// Reads a single specialization by its identifier.
    /// </summary>
    /// <param name="entityId">Identifier of the specialization.</param>
    /// <returns>The specialization if found; otherwise null.</returns>
    public async Task<Specialization?> Read(int entityId)
    {
        return await context.Specializations.FirstOrDefaultAsync(e => e.Id == entityId);
    }

    /// <summary>
    /// Reads all specializations from the database.
    /// </summary>
    /// <returns>List of all specializations.</returns>
    public async Task<IList<Specialization>> ReadAll()
    {
        return await context.Specializations.ToListAsync();
    }

    /// <summary>
    /// Updates an existing specialization.
    /// </summary>
    /// <param name="entity">Specialization with updated data.</param>
    /// <returns>The updated specialization.</returns>
    public async Task<Specialization> Update(Specialization entity)
    {
        context.Specializations.Update(entity);

        await context.SaveChangesAsync();

        return entity;
    }
}