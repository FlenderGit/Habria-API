using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Buildings.Commands.GenerateExcelBuilding;
using Application.Common.Interfaces.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Infrastructure.Data;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class BuildingRepository(DataContext _context, IMapper _mapper) : IBuildingRepository
{
    public async Task<Option<BuildingReportDTO>> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        decimal _id = id;
        BuildingReportDTO building = await _context.Buildings
            .ProjectTo<BuildingReportDTO>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(v => v.Id == id, cancellationToken);
        return building is not null ? Option<BuildingReportDTO>.Some(building) : Option<BuildingReportDTO>.None;
    }
}
