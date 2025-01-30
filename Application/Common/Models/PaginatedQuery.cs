using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models;

public class PaginatedQuery
{
    public int Page { get; init; } = 1;
    public int PerPage { get; init; } = 10;
    public string Query { get; init; } = string.Empty;
}
