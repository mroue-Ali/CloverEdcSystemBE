using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CloverEdc.Core.Models;

public class CrfField : EntityBase
{
    public string FieldName { get; set; }
    public string? ValidationRules { get; set; }
    public bool IsRequired { get; set; }
    
    public Guid CrfFileId { get; set; }
    public CrfFile CrfFile { get; set; }
    
    public Guid BaseFieldId { get; set; }
    public BaseField BaseField { get; set; }

    public Guid? RequiredOptionId { get; set; }
    [NotMapped]
    public DropDownOption RequiredOption { get; set; }
    
    public String? RequiredFieldValue { get; set; }
    public Guid? RequiredFieldId { get; set; }
    [NotMapped]
    public CrfField RequiredField { get; set; }
    [JsonIgnore]
    [NotMapped]
    public ICollection<CrfValue>? CrfValues { get; set; }
    
}