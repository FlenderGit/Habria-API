using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Buildings.Queries.GetBuilding;
using Application.Common.Interfaces.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Repositories;
internal class ObservationRepository(DataContext _context) : IObservationRepository
{
    public IQueryable<Observation> GetByBuildingId(int id) => _context.Observations.AsNoTracking().Where(e => e.BuildingId == id);
}
