using AutoMapper;
using Home_app.Models.Health;
using Home_app.Models.Health.Dto;

namespace Home_app.Models.AutoMapper;

public class HealthMapper : Profile
{
    public HealthMapper()
    {
        CreateMap<RecordCreateDto, HealthRecord>();
        CreateMap<MeasurementCreateDto, Measurement>();
        CreateMap<LiftCreateDto, Lift>();
    }
}