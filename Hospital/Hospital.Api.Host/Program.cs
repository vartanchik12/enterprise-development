using Hospital.Application;
using Hospital.Application.Contracts;
using Hospital.Application.Contracts.Appointments;
using Hospital.Application.Contracts.Doctors;
using Hospital.Application.Contracts.Patients;
using Hospital.Application.Contracts.Specializations;
using Hospital.Application.Services;
using Hospital.Domain;
using Hospital.Domain.Data;
using Hospital.Domain.Model;
using Hospital.Infrastructure.EfCore;
using Hospital.Infrastructure.EfCore.Repositories;
using Hospital.ServiceDefaults;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new HospitalProfile());
});

builder.Services.AddSingleton<DataSeed>();

builder.Services.AddScoped<IRepository<Appointment, int>, AppointmentRepository>();
builder.Services.AddScoped<IRepository<Doctor, int>, DoctorRepository>();
builder.Services.AddScoped<IRepository<Patient, int>, PatientRepository>();
builder.Services.AddScoped<IRepository<Specialization, int>, SpecializationRepository>();

builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IApplicationService<PatientDto, PatientCreateUpdateDto, int>, PatientService>();
builder.Services.AddScoped<IApplicationService<SpecializationDto, SpecializationCreateUpdateDto, int>, SpecializationService>();

builder.Services.AddControllers().AddJsonOptions(o =>
{
    o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var assemblies = AppDomain.CurrentDomain.GetAssemblies()
        .Where(a => a.GetName().Name!.StartsWith("Hospital"))
        .Distinct();

    foreach (var assembly in assemblies)
    {
        var xmlFile = $"{assembly.GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        if (File.Exists(xmlPath))
            c.IncludeXmlComments(xmlPath);
    }

    c.UseInlineDefinitionsForEnums();
});

builder.AddMongoDBClient("hospital");

builder.Services.AddDbContext<HospitalDbContext>((services, o) =>
{
    var db = services.GetRequiredService<IMongoDatabase>();
    o.UseMongoDB(db.Client, db.DatabaseNamespace.DatabaseName);
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<HospitalDbContext>();
    var dataSeed = scope.ServiceProvider.GetRequiredService<DataSeed>();

    if (!dbContext.Doctors.Any())
    {
        foreach (var spec in DataSeed.Specializations)
            await dbContext.Specializations.AddAsync(spec);

        foreach (var doctor in dataSeed.Doctors)
            await dbContext.Doctors.AddAsync(doctor);

        foreach (var patient in dataSeed.Patients)
            await dbContext.Patients.AddAsync(patient);

        foreach (var appointment in dataSeed.Appointments)
            await dbContext.Appointments.AddAsync(appointment);

        await dbContext.SaveChangesAsync();
    }
}

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
