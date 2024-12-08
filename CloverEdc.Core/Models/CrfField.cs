namespace CloverEdc.Core.Models;

public class CrfField : EntityBase
{
    public string FieldName { get; set; }
    public string FieldType { get; set; }
    public string ValidationRules { get; set; }
    public bool IsRequired { get; set; }
    
    public Guid? RequiredFieldId { get; set; }
    
    public Guid CrfPageId { get; set; }
    public CrfPage CrfPage { get; set; }
}