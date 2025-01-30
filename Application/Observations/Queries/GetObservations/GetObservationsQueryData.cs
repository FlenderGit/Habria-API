using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Models;

namespace Application.Observations.Queries.GetObservations;
public class GetObservationsQueryData: PaginatedQuery
{
    public int Chapter { get; init; } = 0;
    public int Type { get; init; } = 0;
}
