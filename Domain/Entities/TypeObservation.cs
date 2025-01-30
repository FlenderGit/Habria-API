using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

[Table("TypeObs")]
public class TypeObservation
{
    [Key]
    [Column("CdTypeObs")]
    public int Id { get; set; }

    [Column("LibTypeObs")]
    public required string Label { get; set; }

    [Column("CdTypeChapitre")]
    public int TypeChapitreId { get; set; }


    public TypeChapitre TypeChapitre { get; set; }


}
