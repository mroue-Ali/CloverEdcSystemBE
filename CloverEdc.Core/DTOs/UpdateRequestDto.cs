namespace CloverEdc.Core.DTOs;

public class UpdateRequestDto
{
    public Guid CrfValueId { get; set; }

    public string Status { get; set; } = "Pending";
    public string Reason { get; set; }
    public string NewValue { get; set; }

    public Guid CrcId { get; set; }
}