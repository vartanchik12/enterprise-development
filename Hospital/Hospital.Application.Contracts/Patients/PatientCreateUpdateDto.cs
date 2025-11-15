using Hospital.Domain.Model;

namespace Hospital.Application.Contracts.Patients;

/// <summary>
/// DTO for creating or updating a patient's information.
/// </summary>
/// <param name="Passport">The passport number of the patient.</param>
/// <param name="FullName">The full name of the patient.</param>
/// <param name="Sex">The gender of the patient.</param>
/// <param name="BirthDate">The birth date of the patient.</param>
/// <param name="Address">The address of the patient (optional).</param>
/// <param name="BloodType">The blood type of the patient (optional).</param>
/// <param name="RHFactor">The Rh factor of the patient (optional).</param>
/// <param name="PhoneNumber">The phone number of the patient (optional).</param>
public record PatientCreateUpdateDto(string Passport, string FullName, Sex Sex, DateOnly BirthDate, string? Address, BloodType? BloodType, RHFactor? RHFactor, string? PhoneNumber);