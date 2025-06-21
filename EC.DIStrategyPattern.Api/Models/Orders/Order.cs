namespace EC.DIStrategyPattern.Api.Models.Orders;

public class Order
{
    public Guid? OrderId { get; set; }
    public string? CustomerId { get; set; }
    public string? OrderNumber { get; set; }
}
