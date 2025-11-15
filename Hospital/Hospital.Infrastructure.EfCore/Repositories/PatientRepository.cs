using Hospital.Domain;
using Hospital.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.EfCore.Repositories;

/// <summary>
/// Repository for managing <see cref="Patient"/> entities.
/// Provides basic CRUD operations using <see cref="HospitalDbContext"/>.
/// </summary>
public class PatientRepository(HospitalDbContext context) : IRepository<Patient, int>
{
    /// <summary>
    /// Creates a new <see cref="Patient"/> in the database.
    /// </summary>
    /// <param name="entity">Patient to create.</param>
    /// <returns>The created patient.</returns>
    public async Task<Patient> Create(Patient entity)
    {
        var result = await context.Patients.AddAsync(entity);
        await context.SaveChangesAsync();
        return result.Entity;
    }

    /// <summary>
    /// Deletes a patient by its identifier.
    /// </summary>
    /// <param name="entityId">Identifier of the patient.</param>
    /// <returns>true if the patient was found and deleted; otherwise false.</returns>
    public async Task<bool> Delete(int entityId)
    {
        var entity = await context.Patients.FirstOrDefaultAsync(e => e.Id == entityId);

        if (entity == null)
            return false;

        context.Patients.Remove(entity);
        await context.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// Reads a single patient by its identifier.
    /// </summary>
    /// <param name="entityId">Identifier of the patient.</param>
    /// <returns>The patient if found; otherwise null.</returns>
    public async Task<Patient?> Read(int entityId)
    {
        return await context.Patients.FirstOrDefaultAsync(e => e.Id == entityId);
    }

    /// <summary>
    /// Reads all patients from the database.
    /// </summary>
    /// <returns>List of all patients.</returns>
    public async Task<IList<Patient>> ReadAll()
    {
        return await context.Patients.ToListAsync();
    }

    /// <summary>
    /// Updates an existing patient.
    /// </summary>
    /// <param name="entity">Patient with updated data.</param>
    /// <returns>The updated patient.</returns>
    public async Task<Patient> Update(Patient entity)
    {
        context.Patients.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }
}
