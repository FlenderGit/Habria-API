using System.Diagnostics;
using Application.Buildings.Queries.GetBuilding;
using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LanguageExt;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Buidings.Queries.GetBuilding;

public record GetBuildingQuery(int id) : IRequest<Option<BuildingDTO>>;

public class GetBuildingQueryHandler : IRequestHandler<GetBuildingQuery, Option<BuildingDTO>>
{
    private readonly IDataContext _context;
    private readonly IMapper _mapper;

    public GetBuildingQueryHandler(IDataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Option<BuildingDTO>> Handle(GetBuildingQuery request, CancellationToken cancellationToken)
    {
        Task<BuildingDTO> query = _context.Buildings
            .Where(x => x.Id == request.id)
            .ProjectTo<BuildingDTO>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(cancellationToken);

        if (query.Result is null)
        {
            return Option<BuildingDTO>.None;
        }

        return Option<BuildingDTO>.Some(query.Result);
    }
}
