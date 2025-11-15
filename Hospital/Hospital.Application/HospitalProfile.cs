using AutoMapper;
using Hospital.Application.Contracts.Appointments;
using Hospital.Application.Contracts.Doctors;
using Hospital.Application.Contracts.Patients;
using Hospital.Application.Contracts.Specializations;
using Hospital.Domain.Model;

namespace Hospital.Application;

/// <summary>
/// Mapper configuration for mapping between Domain and DTO models.
/// </summary>
public class HospitalProfile : Profile
{
    public HospitalProfile()
    {
        CreateMap<Appointment, AppointmentDto>();
        CreateMap<AppointmentCreateUpdateDto, Appointment>();

        CreateMap<Doctor, DoctorDto>();
        CreateMap<DoctorCreateUpdateDto, Doctor>()
            .ForMember(dest => dest.Specialization, opt => opt.Ignore());

        CreateMap<Patient, PatientDto>();
        CreateMap<PatientCreateUpdateDto, Patient>();

        CreateMap<Specialization, SpecializationDto>();
        CreateMap<SpecializationCreateUpdateDto, Specialization>();
    }
}