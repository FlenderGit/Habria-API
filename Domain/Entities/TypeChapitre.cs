using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("TypeChapitre")]
public class TypeChapitre
{
    [Key]
    [Column("CdTypeChapitre")]
    public int Id { get; set; }

    [Column("LibTypeChapitre")]
    public required string Label { get; set; }

    public ICollection<TypeObservation> RelatedTypeObservation { get; } = new List<TypeObservation>();

    public ICollection<Observation> Observations { get; } = new List<Observation>();


}
