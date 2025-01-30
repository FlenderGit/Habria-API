using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

[Table("Obs")]
public class Observation
{
    [Key]
    [Column("Cdobs")]
    public int Id { get; set; }

    [Column("LibObs")]
    public required string Label { get; set; }


    [Column("Remarque")]
    public required string Content { get; set; }

    [Column("DtObs")]
    public DateTime Date {  get; set; }

    [Column("DtCloture")]
    public DateTime? Cloture { get; set; } = default;

    [Column("CdImmeuble")]
    public decimal BuildingId { get; set; }

   

    public Building Building { get; set; }
    [Column("MontantHT")]
    public int Montant { get; set; }

    public TypeNotation TypeNotation { get; set; }
    
    [Column("CdTypeNotation")]

    public int TypeNotationId { get; set; }

    public ICollection<SubObservation> SubObservations { get; } = new List<SubObservation>();

    [Column("CdChapitre")]
    public int TypeChapitreId { get; set; }

    public TypeChapitre TypeChapitre { get; set; }

}
