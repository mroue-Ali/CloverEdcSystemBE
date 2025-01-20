namespace CloverEdc.Core.DTOs;

public class AdverseEventDto
{
    public Guid CrfId { get; set; }
    public string? Description { get; set; } = "";
    public string? Severity { get; set; } = "";
    public bool IsTreated { get; set; } = false;
    public string? Treatment { get; set; } // Nullable
}