using Hospital.Application.Contracts.Appointments;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Host.Controllers;

/// <summary>
/// Controller for managing appointments.
/// Inherits CRUD operations from CrudControllerBase.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AppointmentController(IAppointmentService service, ILogger<AppointmentController> logger)
    : CrudControllerBase<AppointmentDto, AppointmentCreateUpdateDto, int>(service, logger);