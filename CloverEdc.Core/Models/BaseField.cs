using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CloverEdc.Core.Models;

public class BaseField : EntityBase
{
    public string FieldName { get; set; }
    public Guid TypeId { get; set; }
    public Type Type { get; set; }
    
    public Guid CrfTemplateId { get; set; }
    public CrfTemplate CrfTemplate { get; set; }
    // [JsonIgnore]
    public ICollection<DropDownOption>? DropDownOptions { get; set; } = new List<DropDownOption>();
    [JsonIgnore] [NotMapped] public ICollection<CrfField>? CrfFields { get; set; } = new List<CrfField>();
}