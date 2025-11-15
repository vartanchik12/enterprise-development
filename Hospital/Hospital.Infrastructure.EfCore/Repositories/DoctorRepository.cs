using Hospital.Domain;
using Hospital.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.EfCore.Repositories;

/// <summary>
/// Repository for managing <see cref="Doctor"/> entities.
/// Provides basic CRUD operations using <see cref="HospitalDbContext"/>.
/// </summary>
public class DoctorRepository(HospitalDbContext context) : IRepository<Doctor, int>
{
    /// <summary>
    /// Creates a new <see cref="Doctor"/> in the database.
    /// </summary>
    /// <param name="entity">Doctor to create.</param>
    /// <returns>The created doctor.</returns>
    public async Task<Doctor> Create(Doctor entity)
    {
        var result = await context.Doctors.AddAsync(entity);

        await context.SaveChangesAsync();

        return result.Entity;
    }

    /// <summary>
    /// Deletes a doctor by its identifier.
    /// </summary>
    /// <param name="entityId">Identifier of the doctor.</param>
    /// <returns>true if the doctor was found and deleted; otherwise false.</returns>
    public async Task<bool> Delete(int entityId)
    {
        var entity = await context.Doctors.FirstOrDefaultAsync(e => e.Id == entityId);

        if (entity == null)
            return false;

        context.Doctors.Remove(entity);

        await context.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// Reads a single doctor by its identifier.
    /// </summary>
    /// <param name="entityId">Identifier of the doctor.</param>
    /// <returns>The doctor if found; otherwise null.</returns>
    public async Task<Doctor?> Read(int entityId)
    {
        return await context.Doctors.FirstOrDefaultAsync(e => e.Id == entityId);
    }

    /// <summary>
    /// Reads all doctors from the database.
    /// </summary>
    /// <returns>List of all doctors.</returns>
    public async Task<IList<Doctor>> ReadAll()
    {
        return await context.Doctors.ToListAsync();
    }

    /// <summary>
    /// Updates an existing doctor.
    /// </summary>
    /// <param name="entity">Doctor with updated data.</param>
    /// <returns>The updated doctor.</returns>
    public async Task<Doctor> Update(Doctor entity)
    {
        context.Doctors.Update(entity);

        await context.SaveChangesAsync();

        return entity;
    }
}