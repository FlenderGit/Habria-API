using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Buildings.Queries.GetBuildingFilters;

public class TypeChapitreDto
{
    public int Id { get; set; }
    public string Label { get; set; }
    public List<TypeObservationDto> RelatedTypeObservation { get; set; } = new();
}

public class TypeObservationDto
{
    public int Id { get; set; }
    public string Label { get; set; }
}
