namespace CloverEdc.Core.DTOs;

public class BaseFieldDto
{
    public string Name { get; set; }
    public string? Type { get; set; }
    public Guid? TypeId { get; set; }
    public Guid? CrfTemplateId { get; set; }
    public List<string>? Options { get; set; }
}