using CruiseManager.Shared.Infrastructure.Api;
using Microsoft.AspNetCore.Mvc;

namespace CruiseManager.Modules.Boats.Api.Controllers;

[ApiController]
[ProducesDefaultContentType]
[Route($"{BoatsModule.BasePath}/[controller]")]

internal abstract class BaseController : ControllerBase
{
    protected ActionResult<T> OkOrNotFound<T>(T model)
    {
        if (model is null)
        {
            return NotFound();
        }

        return Ok(model);
    }
        
    protected void AddResourceIdHeader(Guid id) => Response.Headers.Add("Resource-ID", id.ToString());
} 