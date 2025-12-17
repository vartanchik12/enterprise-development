using Bogus;
using Hospital.Application.Contracts.Appointments;

namespace Hospital.Generator.RabbitMq.Host;

/// <summary>
/// Generates test appointment contracts (<see cref="AppointmentCreateUpdateDto"/>) using Bogus.
/// Intended for seeding data publishing to RabbitMQ.
/// </summary>
public static class AppointmentGenerator
{
    /// <summary>
    /// Generates a list of <see cref="AppointmentCreateUpdateDto"/> contracts with randomized fields.
    /// </summary>
    /// <param name="count">Number of contracts to generate.</param>
    /// <returns>List of generated appointment contracts.</returns>
    public static List<AppointmentCreateUpdateDto> GenerateContracts(int count) =>
        new Faker<AppointmentCreateUpdateDto>()
            .CustomInstantiator(f => new AppointmentCreateUpdateDto(
                AppointmentTime: f.Date.Between(DateTime.UtcNow.AddDays(-120), DateTime.UtcNow.AddDays(60)),
                RoomNumber: f.Random.Int(100, 350),
                IsFollow: f.Random.Bool(),
                PatientId: f.Random.Int(1, 24),
                DoctorId: f.Random.Int(1, 20)
            ))
            .Generate(count);
}