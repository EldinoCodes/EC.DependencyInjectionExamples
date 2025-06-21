using EC.DIStrategyPattern.Api.Data.Repositories.Orders;
using EC.DIStrategyPattern.Api.Models.Orders;

namespace EC.DIStrategyPattern.Api.Services.Orders;

public class Customer2OrderService(ILogger<Customer2OrderService> logger, IOrderRepository orderRepository) : BaseOrderService(logger, orderRepository)
{
    private readonly ILogger<Customer2OrderService> _logger = logger;

    public override void ProcessOrder(Order? order)
    {
        _logger.LogInformation("Doing custom logic for {source} against the order: {OrderId}", GetType().Name, order?.OrderNumber);

        // still call the base implementation as default logic is okay here.
        base.ProcessOrder(order);
    }
}