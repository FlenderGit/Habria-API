using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Buildings.Queries.GetBuilding;
using AutoMapper;

namespace Application.Common;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<Domain.Entities.Building, BuildingDTO>()
            .ForMember(dest => dest.Observations, opt => opt.MapFrom(src => src.Observations));
        CreateMap<Domain.Entities.Observation, ObservationViewDTO>();
    }
}
