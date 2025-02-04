using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("TblLstImmTertiaire")]
public class Building
{
    [Key]
    [Column("PK_IMMEUBLE")]
    public decimal Id { get; set; }

    [Column("NOM_IMMEUBLE")]

    public string Name { get; set; }

    [Column("NOM")]

    public string Owner { get; set; }

    [Column("VILLE")]
    public string City { get; set; }

    [Column("CODPOS")]
    public string Zipcode { get; set; }

    [Column("ADRLGN1")]
    public string Address1 { get; set; }

    [Column("ADRLGN2")]
    public string Address2 { get; set; }


    public ICollection<Observation> Observations { get; } = new List<Observation>();

}
