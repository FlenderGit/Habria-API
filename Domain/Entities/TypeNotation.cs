using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

[Table("TypeNotation")]
public class TypeNotation
{
    [Key]
    [Column("CdTypeNotation")]
    public int Id { get; set; }

    [Column("LibNotation")]
    public required string Label { get; set; }

    public ICollection<Observation> Observations { get; } = new List<Observation>();

}
