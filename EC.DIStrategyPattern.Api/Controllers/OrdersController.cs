using EC.DIStrategyPattern.Api.Models.Orders;
using EC.DIStrategyPattern.Api.Strategies;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace EC.DIStrategyPattern.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController(ILogger<OrdersController> logger, IOrderServiceStrategy orderServiceStrategy) : ControllerBase
{
    private readonly ILogger<OrdersController> _logger = logger;
    private readonly IOrderServiceStrategy _orderServiceStrategy = orderServiceStrategy;

    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Post(Order? order)
    {
        if(order is null) return BadRequest("Order cannot be null.");

        var orderService = _orderServiceStrategy.OrderServiceGet(order);
        ArgumentNullException.ThrowIfNull(orderService, "Order service cannot be identified.");

        orderService.ProcessOrder(order);

        return Ok();
    }
}
