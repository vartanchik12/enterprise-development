using Hospital.Domain.Model;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Hospital.Infrastructure.EfCore;

/// <summary>
/// EF Core database context for domain.
/// </summary>
public class HospitalDbContext(DbContextOptions options) : DbContext(options)
{
    /// <summary>
    /// Appointments in the database.
    /// </summary>
    public DbSet<Appointment> Appointments { get; set; }

    /// <summary>
    /// Doctors in the database.
    /// </summary>
    public DbSet<Doctor> Doctors { get; set; }

    /// <summary>
    /// Patients in the database.
    /// </summary>
    public DbSet<Patient> Patients { get; set; }

    /// <summary>
    /// Specializations in the database.
    /// </summary>
    public DbSet<Specialization> Specializations { get; set; }

    /// <summary>
    /// Configures entity relationships, keys.
    /// </summary>
    /// <param name="modelBuilder">The model builder used to configure entities.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(builder =>
        {
            builder.ToCollection("appointments");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasElementName("_id");

            builder.Property(b => b.AppointmentTime)
                .IsRequired()
                .HasElementName("appointment_time");

            builder.Property(b => b.RoomNumber)
                .IsRequired()
                .HasElementName("room_number");

            builder.Property(b => b.IsFollow)
                .IsRequired()
                .HasElementName("is_follow");

            builder.Property(b => b.PatientId)
                .IsRequired()
                .HasElementName("patient_id");

            builder.Property(b => b.DoctorId)
                .IsRequired()
                .HasElementName("doctor_id");
        });

        modelBuilder.Entity<Doctor>(builder =>
        {
            builder.ToCollection("doctors");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasElementName("_id");

            builder.Property(b => b.Passport)
                .IsRequired()
                .HasMaxLength(32)
                .HasElementName("passport");

            builder.Property(b => b.FullName)
                .IsRequired()
                .HasMaxLength(200)
                .HasElementName("full_name");

            builder.Property(b => b.BirthDate)
                .IsRequired()
                .HasElementName("birth_date");

            builder.Property(b => b.WorkExperience)
                .HasElementName("work_experience");
        });

        modelBuilder.Entity<Patient>(builder =>
        {
            builder.ToCollection("patients");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasElementName("_id");

            builder.Property(b => b.Passport)
                .IsRequired()
                .HasMaxLength(32)
                .HasElementName("passport");

            builder.Property(b => b.FullName)
                .IsRequired()
                .HasMaxLength(200)
                .HasElementName("full_name");

            builder.Property(b => b.Sex)
                .IsRequired()
                .HasConversion<string>()
                .HasElementName("sex");

            builder.Property(b => b.BirthDate)
                .IsRequired()
                .HasElementName("birth_date");

            builder.Property(b => b.Address)
                .HasMaxLength(300)
                .HasElementName("address");

            builder.Property(b => b.BloodType)
                .HasConversion<string>()
                .HasElementName("blood_type");

            builder.Property(b => b.RHFactor)
                .HasConversion<string>()
                .HasElementName("rh_factor");

            builder.Property(b => b.PhoneNumber)
                .HasMaxLength(32)
                .HasElementName("phone_number");
        });

        modelBuilder.Entity<Specialization>(builder =>
        {
            builder.ToCollection("specializations");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasElementName("_id");

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasElementName("name");
        });
    }
}