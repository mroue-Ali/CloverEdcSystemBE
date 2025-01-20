namespace CloverEdc.Core.Models;

public class DmQuery : EntityBase
{
    public Guid QueryId { get; set; }
    public Query Query { get; set; }

    public Guid DmId { get; set; }
    public Dm Dm { get; set; } 
}
