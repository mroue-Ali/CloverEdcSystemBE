namespace CloverEdc.Core.DTOs;

public class QueryDto
{
    public Guid CrfValueId { get; set; }
    public Guid DmId { get; set; }

    public string QueryText { get; set; }
    public string Status { get; set; } = "Pending";
}