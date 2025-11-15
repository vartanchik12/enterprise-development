using Hospital.Domain;
using Hospital.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.EfCore.Repositories;

/// <summary>
/// Repository for managing <see cref="Appointment"/> entities.
/// Provides basic CRUD operations using <see cref="HospitalDbContext"/>.
/// </summary>
public class AppointmentRepository(HospitalDbContext context) : IRepository<Appointment, int>
{
    /// <summary>
    /// Creates a new <see cref="Appointment"/> in the database.
    /// </summary>
    /// <param name="entity">Appointment to create.</param>
    /// <returns>The created appointment.</returns>
    public async Task<Appointment> Create(Appointment entity)
    {
        var result = await context.Appointments.AddAsync(entity);

        await context.SaveChangesAsync();

        return result.Entity;
    }

    /// <summary>
    /// Deletes an appointment by its identifier.
    /// </summary>
    /// <param name="entityId">Identifier of the appointment.</param>
    /// <returns>true if the appointment was found and deleted; otherwise false.</returns>
    public async Task<bool> Delete(int entityId)
    {
        var entity = await context.Appointments.FirstOrDefaultAsync(e => e.Id == entityId);

        if (entity == null)
            return false;

        context.Appointments.Remove(entity);

        await context.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// Reads a single appointment by its identifier.
    /// </summary>
    /// <param name="entityId">Identifier of the appointment.</param>
    /// <returns>The appointment if found; otherwise null.</returns>
    public async Task<Appointment?> Read(int entityId)
    {
        return await context.Appointments.FirstOrDefaultAsync(e => e.Id == entityId);
    }

    /// <summary>
    /// Reads all appointments from the database.
    /// </summary>
    /// <returns>List of all appointments.</returns>
    public async Task<IList<Appointment>> ReadAll()
    {
        return await context.Appointments.ToListAsync();
    }

    /// <summary>
    /// Updates an existing appointment.
    /// </summary>
    /// <param name="entity">Appointment with updated data.</param>
    /// <returns>The updated appointment.</returns>
    public async Task<Appointment> Update(Appointment entity)
    {
        context.Appointments.Update(entity);

        await context.SaveChangesAsync();

        return entity;
    }
}