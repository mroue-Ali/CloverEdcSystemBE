using System.ComponentModel.DataAnnotations.Schema;

namespace CloverEdc.Core.Models;

public class DropDownOption : EntityBase
{
    
    public string Value { get; set; }
    public Guid BaseFieldId { get; set; }
    
    [NotMapped] 
    public BaseField BaseField { get; set; }
    
}