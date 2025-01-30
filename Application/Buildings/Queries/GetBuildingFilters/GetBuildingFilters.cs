using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Buildings.Queries.GetBuildingFilters;

public record GetBuildingFiltersQuery() : IRequest<List<TypeChapitreDto>>;

public class GetBuildingFilters: IRequestHandler<GetBuildingFiltersQuery, List<TypeChapitreDto>>

{
    private readonly IDataContext _context;

    public GetBuildingFilters(IDataContext context) => _context = context;

    public async Task<List<TypeChapitreDto>> Handle(GetBuildingFiltersQuery request, CancellationToken cancellationToken)
    {
        List<TypeChapitreDto> chapitres = await _context.Chapitres
        .Select(c => new TypeChapitreDto
        {
            Id = c.Id,
            Label = c.Label,
            RelatedTypeObservation = c.RelatedTypeObservation
                .Select(o => new TypeObservationDto
                {
                    Id = o.Id,
                    Label = o.Label
                })
                .ToList()
        })
        .ToListAsync(cancellationToken);

        return chapitres;
    }
}
