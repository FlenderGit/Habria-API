using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

[Table("SuiteObs")]
public class SubObservation
{
    [Key]
    [Column("CdSuiteObs")]
    public int Id { get; set; }

    [Column("LibSuite")]
    public required string Label { get; set; }

    [Column("CdObs")]
    public int ObservationId { get; set; }
    public Observation Observation { get; set; }
    
    [Column("DtSuite")]
    public DateTime Date { get; set; }


}
