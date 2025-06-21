namespace EC.DIStrategyPattern.Api.Models.StatusUpdates;

public class StatusUpdate
{
    public Guid? StatusUpdateId { get; set; }   
    public string? CustomerId { get; set; }
    public string? OrderNumber { get; set; }
}
