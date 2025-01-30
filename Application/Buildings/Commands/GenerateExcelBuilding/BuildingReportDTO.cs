using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Buildings.Queries.GetBuilding;
using AutoMapper;
using Domain.Entities;

namespace Application.Buildings.Commands.GenerateExcelBuilding;
public class BuildingReportDTO: BuildingDTO
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Building, BuildingReportDTO>()
                .ForMember(dest => dest.Observations, opt => opt.MapFrom(src => src.Observations));
            CreateMap<Domain.Entities.Observation, ObservationViewDTO>();
        }
    }
}
