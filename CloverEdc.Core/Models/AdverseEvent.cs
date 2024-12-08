namespace CloverEdc.Core.Models;

public class AdverseEvent : EntityBase
{
    public Guid CrfId { get; set; }
    public Crf Crf { get; set; }

    public string Description { get; set; }
    public string Severity { get; set; }
    public bool IsTreated { get; set; }

    public string? Treatment { get; set; } // Nullable
}
