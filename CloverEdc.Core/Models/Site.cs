using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CloverEdc.Core.Models;

public class Site : EntityBase
{
    public string Name { get; set; }
    public string Location { get; set; }

    public Guid? PiId { get; set; }
    public Pi Pi { get; set; }
    public Guid StudyId { get; set; }
    public Study Study { get; set; }
    [JsonIgnore]
    [NotMapped]
    public ICollection<Patient> Patients { get; set; }
    
    [NotMapped]
    public bool hasPi { get; set; }
}
