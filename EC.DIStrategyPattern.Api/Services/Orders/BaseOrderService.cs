using EC.DIStrategyPattern.Api.Data.Repositories.Orders;
using EC.DIStrategyPattern.Api.Models.Orders;

namespace EC.DIStrategyPattern.Api.Services.Orders;

public interface IOrderService
{
    void ProcessOrder(Order? order);
}

public abstract class BaseOrderService(ILogger<BaseOrderService> logger, IOrderRepository orderRepository) : IOrderService
{
    private readonly ILogger<BaseOrderService> _logger = logger;
    private readonly IOrderRepository _orderRepository = orderRepository;

    public virtual void ProcessOrder(Order? order)
    {
        _logger.LogInformation("{source} processing order '{order}'", GetType().FullName, order?.OrderNumber);

        _orderRepository.OrderAdd(order);
    }
}
