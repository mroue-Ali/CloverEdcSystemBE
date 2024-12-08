namespace CloverEdc.Core.DTOs;

public class PatientDto
{
    public string Name { get; set; }
    public string Code { get; set; }

    public Guid StudyId { get; set; }

    public Guid SiteId { get; set; }
    public string RandomizationArm { get; set; } = "";
}