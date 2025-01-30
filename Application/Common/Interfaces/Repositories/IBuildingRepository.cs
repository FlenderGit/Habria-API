using Application.Buildings.Commands.GenerateExcelBuilding;
using LanguageExt;
using LanguageExt.Common;

namespace Application.Common.Interfaces.Repositories;
public interface IBuildingRepository
{
    Task<Option<BuildingReportDTO>> GetByIdAsync(int id, CancellationToken cancellationToken);
}
