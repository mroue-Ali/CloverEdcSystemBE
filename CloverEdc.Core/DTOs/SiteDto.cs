namespace CloverEdc.Core.DTOs;

public class SiteDto
{
    public string Name { get; set; }
    public string Location { get; set; }
    public Guid? StudyId { get; set; }
    public List<Guid> siteIds { get; set; }
}