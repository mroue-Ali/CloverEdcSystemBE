namespace CloverEdc.Core.DTOs;

public class CrfFieldDto
{
    public string FieldName { get; set; }
    public string FieldType { get; set; }
    public string? ValidationRules { get; set; } = "";
    public bool IsRequired { get; set; } = false;
    
    public Guid? RequiredFieldId { get; set; }
    
    public Guid CrfPageId { get; set; }
}