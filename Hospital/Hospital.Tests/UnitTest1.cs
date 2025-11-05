using Hospital.Domain;
using System.Net.WebSockets;

namespace Hospital.Tests;

/// <summary>
/// Unit tests for Hospital.Models.
/// </summary>
public class HospitalTests(HospitalFixture fixture) : IClassFixture<HospitalFixture>
{
    /// <summary>
    /// Test that count doctors with at least 10 years of expirience.
    /// </summary>
    [Fact]
    public void CountDoctorsWithMinimum10YearsExperience_ReturnsCorrectNumber()
    {
        var expectedCount = 8;
        var expectedFirstId = 1;

        var actual = fixture.Doctors
            .Where(doctor => doctor.WorkExperience >= 10)
            .ToList();

        Assert.Equal(expectedCount, actual.Count());
        Assert.Equal(expectedFirstId, actual[0].ID);
    }

    /// <summary>
    /// Test that returns patients for specific doctor ordered by full name.
    /// </summary>
    [Fact]
    public void GetPatientsByDoctorId_OrderedByName_ReturnsCorrectPatients()
    {
        var DoctorID = 1;
        var expectedCount = 3;
        var expectedId = 3;

        var actual = fixture.Appointments
        .Where(a => a.DoctorId == DoctorID)
        .Join(fixture.Patients,
             a => a.PatientId,
             p => p.ID,
            (a, p) => p)
        .OrderBy(p => p.FullName)
        .ToList();

        Assert.Equal(expectedCount, actual.Count());
        Assert.Equal(expectedId, actual[0].ID);
    }

    /// <summary>
    /// Test that counts follow-up appointments for the last month.
    /// </summary>
    [Fact]
    public void CountFollowUpAppointmentsLastMonth_ReturnsCorrectNumber()
    {
        var expected = 7;
        var today = new DateTime(2025, 10, 20);
        var monthAgo = today.AddMonths(-1);

        var actual = fixture.Appointments
            .Count(a => a.AppointmentTime >= monthAgo && a.IsFollow);

        Assert.Equal(expected, actual);
    }

    /// <summary>
    /// Test that returns patients over 30 years with multiple doctors ordered by birth date.
    /// </summary>
    [Fact]
    public void GetPatientsOver30WithMultipleDoctors_OrderedByBirthDate_ReturnsCorrectPatients()
    {
        var expected = 2;
        var today = new DateTime(2025, 10, 20);
        var ageLimit = today.AddYears(-30);

        var result = fixture.Patients
            .Where(p => p.BirthDate <= ageLimit)
            .Where(p => fixture.Appointments
                        .Where(a => a.PatientId == p.ID)
                        .Select(a => a.DoctorId)
                        .Distinct()
                        .Count() > 1)
            .OrderBy(p => p.BirthDate)
            .Select(p => p.ID)
            .ToList();

        Assert.NotNull(result);
        Assert.Equal(expected, result.Count);

        List<int> expectedPatientsIds = [11, 12];
        Assert.Equal(expectedPatientsIds, result);
    }

    /// <summary>
    /// Test that returns appointments for specific room in current month ordered by time.
    /// </summary>
    [Fact]
    public void GetAppointmentsByRoomCurrentMonth_OrderedByTime_ReturnsCorrectAppointments()
    {
        var today = new DateTime(2025, 10, 25);
        var officeNumber = 101;

        var resultAppointmentTimes = fixture.Appointments
            .Where(a => a.RoomNumber == officeNumber
                        && a.AppointmentTime.Year == today.Year
                        && a.AppointmentTime.Month == today.Month)
            .OrderBy(a => a.AppointmentTime)
            .Select(a => a.AppointmentTime)
            .ToList();

        List<DateTime> expectedAppointmentTimes = [
            new DateTime(2025, 10, 15),
            new DateTime(2025, 10, 20)
        ];
        Assert.Equal(expectedAppointmentTimes, resultAppointmentTimes);
    }
}