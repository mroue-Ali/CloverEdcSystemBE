using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CloverEdc.Core.Models;

public class DropDownOption : EntityBase
{
    
    public string Value { get; set; }
    public Guid BaseFieldId { get; set; }
    
    // [NotMapped] 
    [JsonIgnore]
    public BaseField BaseField { get; set; }
    
}