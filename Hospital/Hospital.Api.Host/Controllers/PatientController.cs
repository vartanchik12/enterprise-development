using Hospital.Application.Contracts;
using Hospital.Application.Contracts.Patients;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Host.Controllers;

/// <summary>
/// Controller for managing patients.
/// Inherits CRUD operations from CrudControllerBase/>.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PatientController(IApplicationService<PatientDto, PatientCreateUpdateDto, int> service, ILogger<PatientController> logger) 
    : CrudControllerBase<PatientDto, PatientCreateUpdateDto, int>(service, logger);