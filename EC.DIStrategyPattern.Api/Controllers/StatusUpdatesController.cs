using EC.DIStrategyPattern.Api.Models.StatusUpdates;
using EC.DIStrategyPattern.Api.Strategies;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace EC.DIStrategyPattern.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class StatusUpdatesController(ILogger<StatusUpdatesController> logger, IStatusUpdateServiceStrategy statusUpdateServiceStrategy) : ControllerBase
{
    private readonly ILogger<StatusUpdatesController> _logger = logger;
    private readonly IStatusUpdateServiceStrategy _statusUpdateServiceStrategy = statusUpdateServiceStrategy;

    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Post(StatusUpdate? statusUpdate)
    {
        if(statusUpdate is null) return BadRequest("StatusUpdate cannot be null.");

        var statusUpdateService = _statusUpdateServiceStrategy.StatusUpdateServiceGet(statusUpdate);
        ArgumentNullException.ThrowIfNull(statusUpdateService, "StatusUpdate service cannot be identified.");

        statusUpdateService.ProcessStatusUpdate(statusUpdate);

        return Ok();
    }
}
