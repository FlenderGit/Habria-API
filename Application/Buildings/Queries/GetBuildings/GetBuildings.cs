﻿using Application.Common.Interfaces;
using Application.Common.Models;
using LanguageExt;
using MediatR;

namespace Application.Buildings.Queries.GetBuildings;

public record GetBuildingsQuery(PaginatedQuery data) : IRequest<PaginatedList<BuildingViewDTO>>;

public class GetBuildingQueryHandler : IRequestHandler<GetBuildingsQuery, PaginatedList<BuildingViewDTO>>
{
    private readonly IDataContext _context;

    public GetBuildingQueryHandler(IDataContext context) => _context = context;

    public async Task<PaginatedList<BuildingViewDTO>> Handle(GetBuildingsQuery request, CancellationToken cancellationToken)
    {

        IQueryable<Domain.Entities.Building> buildingQuery = _context.Buildings;

        if (!string.IsNullOrWhiteSpace(request.data.Query))
        {
            string query = request.data.Query;
            buildingQuery = buildingQuery.Where(x
                => x.Name.ToLower().Contains(query)
                || x.Id.ToString().Contains(query)
                || x.City.Contains(query)
            );
        }

        IQueryable<BuildingViewDTO> buildingQueryResponse = buildingQuery.Select(b => new BuildingViewDTO
        {
            Id = b.Id,
            Name = b.Name,
            Owner = b.Owner
        });

        PaginatedList<BuildingViewDTO> paginated = await PaginatedList<BuildingViewDTO>.CreateAsync(buildingQueryResponse, request.data.Page, request.data.PerPage);

        return paginated;
    }
}
