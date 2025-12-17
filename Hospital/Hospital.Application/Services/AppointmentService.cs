using AutoMapper;
using Hospital.Application.Contracts.Appointments;
using Hospital.Domain;
using Hospital.Domain.Model;

namespace Hospital.Application.Services;

/// <summary>
/// Application service for managing <see cref="Appointment"/> entities.
/// Implements basic CRUD operations.
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
        _ = await doctorRepository.Read(dto.DoctorId) ?? throw new KeyNotFoundException($"Doctor with Id {dto.DoctorId} not found");

        _ = await patientRepository.Read(dto.PatientId) ?? throw new KeyNotFoundException($"Patient with Id {dto.PatientId} not found");

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
    /// Retrieves all appointments for the specified doctor.
    /// </summary>
    /// <param name="doctorId">Identifier of the doctor.</param>
    /// <returns>List of appointments for the doctor.</returns>
    public async Task<IList<AppointmentDto>> GetAppointmentsByDoctorId(int doctorId)
    {
        var list = await repository.ReadAll();
        return mapper.Map<IList<AppointmentDto>>(list
            .Where(x => x.DoctorId == doctorId)
            .ToList());
    }

    /// <summary>
    /// Retrieves all appointments for the specified patient.
    /// </summary>
    /// <param name="patientId">Identifier of the patient.</param>
    /// <returns>List of appointments for the patient.</returns>
    public async Task<IList<AppointmentDto>> GetAppointmentsByPatientId(int patientId)
    {
        var list = await repository.ReadAll();

        return mapper.Map<IList<AppointmentDto>>(list
            .Where(x => x.PatientId == patientId)
            .ToList());
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