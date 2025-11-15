using AutoMapper;
using Hospital.Application.Contracts;
using Hospital.Application.Contracts.Appointments;
using Hospital.Application.Contracts.Doctors;
using Hospital.Application.Contracts.Patients;
using Hospital.Domain;
using Hospital.Domain.Model;

namespace Hospital.Application.Services;

/// <summary>
/// Application service for analytics on hospital data.
/// Provides methods to query appointments, doctors, and patients with specific criteria.
/// </summary>
public class AnalyticsService (
    IRepository<Appointment, int> appointmentRepository, 
    IRepository<Doctor, int> doctorRepository, 
    IRepository<Patient, int> patientRepository, 
    IMapper mapper) 
    : IAnalyticsService
{
    /// <summary>
    /// Retrieves all appointments in a specific office for the current month.
    /// </summary>
    /// <param name="officeNumber">Office (room) number.</param>
    /// <returns>List of appointments in the office for the current month.</returns>
    public async Task<IList<AppointmentDto>> GetAppointmentsByOfficeForCurrentMonth(int officeNumber)
    {
        var today = DateTime.UtcNow;
        var appointments = (await appointmentRepository.ReadAll())
            .Where(a => a.RoomNumber == officeNumber &&
                        a.AppointmentTime.Year == today.Year &&
                        a.AppointmentTime.Month == today.Month)
            .OrderBy(a => a.AppointmentTime)
            .ToList();

        return mapper.Map<IList<AppointmentDto>>(appointments);
    }

    /// <summary>
    /// Retrieves all doctors with at least 10 years of work experience.
    /// </summary>
    /// <returns>List of doctors with minimum 10 years of experience.</returns>
    public async Task<IList<DoctorDto>> GetDoctorsWithAtLeast10YearsExperience()
    {
        var doctors = (await doctorRepository.ReadAll())
            .Where(d => d.WorkExperience >= 10)
            .OrderBy(d => d.Id)
            .ToList();

        return mapper.Map<IList<DoctorDto>>(doctors);
    }

    /// <summary>
    /// Retrieves all follow-up appointments that occurred during the last month.
    /// </summary>
    /// <returns>List of follow-up appointments from the previous month.</returns>
    public async Task<IList<AppointmentDto>> GetFollowUpAppointmentsForLastMonth()
    {
        var today = DateTime.UtcNow;
        var lastMonth = today.AddMonths(-1);

        var appointments = (await appointmentRepository.ReadAll())
            .Where(a => a.IsFollow &&
                        a.AppointmentTime.Year == lastMonth.Year &&
                        a.AppointmentTime.Month == lastMonth.Month)
            .OrderBy(a => a.AppointmentTime)
            .ToList();

        return mapper.Map<IList<AppointmentDto>>(appointments);
    }

    /// <summary>
    /// Retrieves all patients who have appointments with a specific doctor.
    /// </summary>
    /// <param name="doctorId">Identifier of the doctor.</param>
    /// <returns>List of patients associated with the doctor.</returns>
    public async Task<IList<PatientDto>> GetPatientsByDoctorId(int doctorId)
    {
        var appointments = (await appointmentRepository.ReadAll())
            .Where(a => a.DoctorId == doctorId)
            .ToList();

        var patientIds = appointments.Select(a => a.PatientId).Distinct();

        var patients = (await patientRepository.ReadAll())
            .Where(p => patientIds.Contains(p.Id))
            .OrderBy(p => p.FullName)
            .ToList();

        return mapper.Map<IList<PatientDto>>(patients);
    }

    /// <summary>
    /// Retrieves all patients over 30 years old who have seen multiple doctors.
    /// </summary>
    /// <returns>List of patients over 30 with appointments with multiple doctors.</returns>
    public async Task<IList<PatientDto>> GetPatientsOver30YearsWithMultipleDoctors()
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        var ageLimit = today.AddYears(-30);

        var allAppointments = await appointmentRepository.ReadAll();
        var patients = (await patientRepository.ReadAll())
            .Where(p => p.BirthDate <= ageLimit &&
                        allAppointments
                            .Where(a => a.PatientId == p.Id)
                            .Select(a => a.DoctorId)
                            .Distinct()
                            .Count() > 1)
            .OrderBy(p => p.BirthDate)
            .ToList();

        return mapper.Map<IList<PatientDto>>(patients);
    }
}