using AutoMapper;
using Home_app.Models.Calendar;
using Home_app.Models.Calendar.Dto;

namespace Home_app.Models.AutoMapper;

public class EventMapper : Profile
{
    public EventMapper()
    {
        CreateMap<EventCreateDto, Event>();
        CreateMap<EventUpdateDto, Event>();
    }
}