using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Models;

namespace Application.Buildings.Queries.GetBuildings;

public class BuildingViewDTO
{
    public decimal Id { get; init; }
    public required string Name { get; init; }
    public required string Zipcode { get; init; }
    public required string City { get; init; }
}
