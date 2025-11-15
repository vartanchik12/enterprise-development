using AutoMapper;
using Hospital.Application.Contracts.Appointments;
using Hospital.Application.Contracts.Doctors;
using Hospital.Application.Contracts.Patients;
using Hospital.Domain;
using Hospital.Domain.Model;

namespace Hospital.Application.Services;

/// <summary>
/// Application service for managing <see cref="Appointment"/> entities.
/// Implements basic CRUD operations and provides access to associated doctors and patients.
/// </summary>
public class AppointmentService(IRepository<Appointment, int> repository, IRepository<Doctor, int> doctorRepository, IRepository<Patient, int> patientRepository, IMapper mapper) 
    : IAppointmentService
{
    /// <summary>
    /// Creates a new appointment.
    /// </summary>
    /// <param name="dto">DTO containing data for creation.</param>
    /// <returns>The created appointment as DTO.</returns>
    public async Task<AppointmentDto> Create(AppointmentCreateUpdateDto dto)
    {
        var entity = mapper.Map<Appointment>(dto);

        var entities = await repository.ReadAll();
        var lastId = entities.Any() ? entities.Max(c => c.Id) : 0;
        entity.Id = lastId + 1;

        var result = await repository.Create(entity);

        return mapper.Map<AppointmentDto>(result);
    }

    /// <summary>
    /// Deletes an appointment by its identifier.
    /// </summary>
    /// <param name="dtoId">Identifier of the appointment.</param>
    /// <returns>True if deletion succeeded, false if not found.</returns>
    public async Task<bool> Delete(int dtoId)
    {
        return await repository.Delete(dtoId);
    }

    /// <summary>
    /// Retrieves an appointment by its identifier.
    /// </summary>
    /// <param name="dtoId">Identifier of the appointment.</param>
    /// <returns>The appointment DTO, or throws if not found.</returns>
    public async Task<AppointmentDto?> Get(int dtoId)
    {
        var entity = await repository.Read(dtoId) ?? throw new KeyNotFoundException($"Entity with Id {dtoId} not found");

        return mapper.Map<AppointmentDto>(entity);
    }

    /// <summary>
    /// Retrieves all appointments.
    /// </summary>
    /// <returns>List of all appointment DTOs.</returns>
    public async Task<IList<AppointmentDto>> GetAll()
    {
        return mapper.Map<List<AppointmentDto>>(await repository.ReadAll());
    }

    /// <summary>
    /// Retrieves the doctor associated with a given appointment.
    /// </summary>
    /// <param name="appointmentId">Identifier of the appointment.</param>
    /// <returns>The doctor DTO linked to the appointment.</returns>
    public async Task<DoctorDto> GetDoctor(int appointmentId)
    {
        var entity = await repository.Read(appointmentId) ?? throw new KeyNotFoundException($"Entity with Id {appointmentId} not found");

        return mapper.Map<DoctorDto>(await doctorRepository.Read(entity.DoctorId));
    }

    /// <summary>
    /// Retrieves the patient associated with a given appointment.
    /// </summary>
    /// <param name="appointmentId">Identifier of the appointment.</param>
    /// <returns>The patient DTO linked to the appointment.</returns>
    public async Task<PatientDto> GetPatient(int appointmentId)
    {
        var entity = await repository.Read(appointmentId) ?? throw new KeyNotFoundException($"Entity with Id {appointmentId} not found");

        return mapper.Map<PatientDto>(await patientRepository.Read(entity.PatientId));
    }

    /// <summary>
    /// Updates an existing appointment.
    /// </summary>
    /// <param name="dto">DTO containing updated data.</param>
    /// <param name="dtoId">Identifier of the appointment to update.</param>
    /// <returns>The updated appointment DTO.</returns>
    public async Task<AppointmentDto> Update(AppointmentCreateUpdateDto dto, int dtoId)
    {
        var entity = await repository.Read(dtoId) ?? throw new KeyNotFoundException($"Entity with Id {dtoId} not found");

        mapper.Map(dto, entity);

        var result = await repository.Update(entity);

        return mapper.Map<AppointmentDto>(result);
    }
}