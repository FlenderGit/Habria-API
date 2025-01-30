using Application.Buildings.Queries.GetBuilding;
using Application.Common.Interfaces.Repositories;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;

namespace Application.Observations.Queries.GetObservations;
public class GetObservationsQueryHandler(IObservationRepository _repository, IMapper _mapper) : IRequestHandler<GetObservationsQuery, PaginatedList<ObservationViewDTO>>
{
    public async Task<PaginatedList<ObservationViewDTO>> Handle(GetObservationsQuery request, CancellationToken cancellationToken)
    {

        IQueryable<Observation> observationQuery = _repository.GetByBuildingId(request.Id);

        GetObservationsQueryData data = request.Request;
        if (!string.IsNullOrEmpty(data.Query))
        {
            observationQuery = observationQuery.Where(v => v.Label.Contains(data.Query));
        }

        if (data.Chapter != 0)
        {
            observationQuery = observationQuery.Where(v => v.TypeChapitre.Id == data.Chapter);
        }

        IQueryable<ObservationViewDTO> observationViewQuery = observationQuery.ProjectTo<ObservationViewDTO>(_mapper.ConfigurationProvider);

        return await PaginatedList<ObservationViewDTO>.CreateAsync(observationViewQuery, data.Page, data.PerPage);

        /* if (!string.IsNullOrEmpty(idTypeObservation))
        {
            observationQuery = observationQuery.Where(v => v.TypeChapitreId == idTypeObservation);
        } */
    }
}
