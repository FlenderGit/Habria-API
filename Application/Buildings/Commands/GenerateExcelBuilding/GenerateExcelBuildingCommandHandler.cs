using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Domain.Entities;
using LanguageExt;
using LanguageExt.Common;
using MediatR;

namespace Application.Buildings.Commands.GenerateExcelBuilding;
public class GenerateExcelBuildingCommandHandler(IBuildingRepository repository, IExcelService excelService) : IRequestHandler<GenerateExcelBuildingCommand, Fin<byte[]>>
{
    private readonly IBuildingRepository _repository = repository;
    private readonly IExcelService _excelService = excelService;


    public async Task<Fin<byte[]>> Handle(GenerateExcelBuildingCommand request, CancellationToken cancellationToken)
    {
        Option<BuildingReportDTO> building = await _repository.GetByIdAsync(request.Id, cancellationToken);

        return building.Match(
            Some: v => Fin<byte[]>.Succ(createExcelBuildingReport(v)),
            None: Fin<byte[]>.Fail("Nope")
        );
    }

    private byte[] createExcelBuildingReport(BuildingReportDTO building)
    {
        byte[] excel = _excelService.GenerateExcel(building);
        return excel;
    }

}

