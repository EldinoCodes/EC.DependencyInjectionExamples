using EC.DIStrategyPattern.Api.Data.Repositories.Orders;

namespace EC.DIStrategyPattern.Api.Services.Orders;

public class OrderService(ILogger<OrderService> logger, IOrderRepository orderRepository) : BaseOrderService(logger, orderRepository)
{
    private readonly ILogger<OrderService> _logger = logger;
    private readonly IOrderRepository _orderRepository = orderRepository;

    /* by default, baseorderservice's implementation of the processorder will be fired */
}
