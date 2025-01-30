using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Buildings.Commands.CreateBuilding;

public record CreateBuildingRequest
(
    string Name,
    string Ville
);
