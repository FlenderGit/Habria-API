using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Buildings.Commands.GenerateExcelBuilding;
using Domain.Entities;

namespace Application.Common.Interfaces.Services;
public interface IExcelService
{
    byte[] GenerateExcel(BuildingReportDTO building, IMapService mapService);
}
