using EC.DIStrategyPattern.Api.Models.Orders;

namespace EC.DIStrategyPattern.Api.Data.Repositories.Orders;

public interface IOrderRepository
{
    void OrderAdd(Order? order);
}

public class OrderRepository(ILogger<OrderRepository> logger) : IOrderRepository
{
    private readonly ILogger<OrderRepository> _logger = logger;

    public void OrderAdd(Order? order)
    {
        if (order is null) return;

        _logger.LogInformation("Adding order '{order}' to the repository.", order?.OrderNumber);
    }
}
