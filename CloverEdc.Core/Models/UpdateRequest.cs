namespace CloverEdc.Core.Models;

public class UpdateRequest : EntityBase
{
    public Guid CrfValueId { get; set; }
    public CrfValue CrfValue { get; set; }

    public string Status { get; set; }
    public string Reason { get; set; }
    public string NewValue { get; set; }

}
