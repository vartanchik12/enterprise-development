using Hospital.Application.Contracts;
using Hospital.Application.Contracts.Specializations;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Host.Controllers;

/// <summary>
/// Controller for managing doctor specializations.
/// Inherits CRUD operations from CrudControllerBase/>.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SpecializationController(IApplicationService<SpecializationDto, SpecializationCreateUpdateDto, int> service, ILogger<SpecializationController> logger) 
    : CrudControllerBase<SpecializationDto, SpecializationCreateUpdateDto, int>(service, logger);