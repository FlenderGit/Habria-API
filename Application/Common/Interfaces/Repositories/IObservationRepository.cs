using Application.Buildings.Commands.GenerateExcelBuilding;
using Application.Buildings.Queries.GetBuilding;
using Domain.Entities;
using LanguageExt;
using LanguageExt.Common;

namespace Application.Common.Interfaces.Repositories;
public interface IObservationRepository
{
    IQueryable<Observation> GetByBuildingId(int id);
}
