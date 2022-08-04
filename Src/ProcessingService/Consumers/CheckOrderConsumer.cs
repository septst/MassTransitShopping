using MassTransit;
using Microsoft.Extensions.Logging;
using ShoppingEvents;

namespace ProcessingService.Consumers;

public class CheckOrderConsumer : IConsumer<CheckOrder>
{
    private readonly ILogger<CheckOrderConsumer> _logger;

    public CheckOrderConsumer(
        ILogger<CheckOrderConsumer> logger)
    {
        _logger = logger;
    }
    
    public Task Consume(ConsumeContext<CheckOrder> context)
    {
        _logger.LogInformation(
            "The Check Order consumer received order id {OrderId}",
            context.Message.OrderId);
        return Task.CompletedTask;
    }
}