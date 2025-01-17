using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CloverEdc.Core.Models;

public class Type : EntityBase
{
    public string Name { get; set; }
    public string DataType { get; set; }
    [JsonIgnore] [NotMapped] public ICollection<BaseField>? BaseFields { get; set; }
}