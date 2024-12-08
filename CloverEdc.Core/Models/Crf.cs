using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CloverEdc.Core.Models;

public class Crf : EntityBase
{
    public Guid StudyId { get; set; }
    public Study Study { get; set; }

    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }

    public Guid CrfTemplateId { get; set; }
    public CrfTemplate CrfTemplate { get; set; }

    [JsonIgnore]
    [NotMapped]
    public ICollection<CrfValue> CrfValues { get; set; }
}
