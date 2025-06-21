using EC.DIStrategyPattern.Api.Models.Orders;
using EC.DIStrategyPattern.Api.Services.Orders;

namespace EC.DIStrategyPattern.Api.Strategies;

public interface IOrderServiceStrategy
{
    IOrderService OrderServiceGet(Order? order);
}

public class OrderServiceStrategy(ILogger<OrderServiceStrategy> logger, IEnumerable<IOrderService> orderServices) : IOrderServiceStrategy
{
    private readonly ILogger<OrderServiceStrategy> _logger = logger;
    private readonly IEnumerable<IOrderService> _orderServices = orderServices;
    public IOrderService OrderServiceGet(Order? order)
    {
        var service = order?.CustomerId switch
        {
            "customer1" => _orderServices.First(o => o.GetType() == typeof(Customer1OrderService)),
            "customer2" => _orderServices.First(o => o.GetType() == typeof(Customer2OrderService)),
            _ => _orderServices.First(o => o.GetType() == typeof(OrderService))
        };
        
        _logger.LogInformation("Using order service: {service} for order: {order}", service.GetType().Name, order?.OrderNumber);

        return service;
    }
}
