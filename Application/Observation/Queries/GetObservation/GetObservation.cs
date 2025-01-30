using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LanguageExt;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Observation.Queries.GetObservation;

public record GetObservationQuery(int id) : IRequest<Option<ObservationDTO>>;

public class GetObservationQueryHandler : IRequestHandler<GetObservationQuery, Option<ObservationDTO>>
{
    private readonly IDataContext _context;
    private readonly IMapper _mapper;

    public GetObservationQueryHandler(IDataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<Option<ObservationDTO>> Handle(GetObservationQuery request, CancellationToken cancellationToken)
    {
        Task<ObservationDTO> query = _context.Observations
            .Where(x => x.Id == request.id)
            .ProjectTo<ObservationDTO>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(cancellationToken);

        if (query.Result is null)
        {
            return Option<ObservationDTO>.None;
        }

        return Option<ObservationDTO>.Some(query.Result);
    }
}
