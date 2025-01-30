using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Buildings.Queries.GetBuilding;
using Application.Common.Models;
using Domain.Entities;
using MediatR;

namespace Application.Observations.Queries.GetObservations;

public record GetObservationsQuery(int Id, GetObservationsQueryData Request): IRequest<PaginatedList<ObservationViewDTO>>;
