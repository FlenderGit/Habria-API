using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Application.Buildings.Queries.GetBuildings;
using AutoMapper;
using Domain.Entities;

namespace Application.Buildings.Queries.GetBuilding;

public class BuildingDTO: BuildingViewDTO
{
    public BuildingDTO() => Observations = Array.Empty<ObservationViewDTO>();
    public IReadOnlyCollection<ObservationViewDTO> Observations { get; init; }
    
    public required string Address1 { get; init; }
    public required string Address2 { get; init; }

    public required string City { get; init; }
    public required string Zipcode { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Building, BuildingDTO>()
                .ForMember(dest => dest.Observations, opt => opt.MapFrom(src => src.Observations));
            CreateMap<Domain.Entities.Observation, ObservationViewDTO>();
        }
    }



}

public class ObservationViewDTO
{
    public int Id { get; init; }
    public required string Label { get; init; }
    public required string Content { get; init; }
    public DateTime Date { get; init; }

    [JsonIgnore]
    public required TypeNotation TypeNotation { get; init; }

    [JsonPropertyName("typeNotation")]
    public string TypeNotationLabel => TypeNotation.Label;
}
