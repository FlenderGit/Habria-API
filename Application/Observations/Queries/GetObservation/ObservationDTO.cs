using AutoMapper;

namespace Application.Observations.Queries.GetObservation;

public class ObservationDTO
{
    public int Id { get; set; }

    public required string Label { get; set; }

    //public required string Content { get; set; } = String.Empty;

    public DateTime Date { get; set; }

    public DateTime? Cloture { get; set; }
    public IReadOnlyCollection<SubObservationDTO> SubObservations { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Domain.Entities.Observation, ObservationDTO>()
                            .ForMember(dest => dest.SubObservations, opt => opt.MapFrom(src => src.SubObservations));
            CreateMap<Domain.Entities.SubObservation, SubObservationDTO>();
        }
    }
}

public class SubObservationDTO
{
    public int Id { get; init; }
    public required string Label { get; set; }
    public DateTime Date { get; set; }

}
