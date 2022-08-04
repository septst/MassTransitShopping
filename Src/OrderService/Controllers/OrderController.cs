using MassTransit;
using Microsoft.AspNetCore.Mvc;
using ShoppingEvents;

namespace OrderService.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ILogger<OrderController> _logger;

    public OrderController(
        IPublishEndpoint publishEndpoint,
        ILogger<OrderController> logger)
    {
        _publishEndpoint = publishEndpoint;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> CheckOrderAsync(Guid orderId)
    {
        _logger.LogInformation("The Check Order request received for Order Id {OrderId}", orderId);
        await _publishEndpoint.Publish<CheckOrder>(new
        {
            InVar.CorrelationId,
            OrderId = orderId,
        });

        return Ok();
    }
}