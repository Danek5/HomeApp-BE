using AutoMapper;
using Home_app.Models.Calendar;
using Home_app.Models.Calendar.Dto;

namespace Home_app.Models.AutoMapper;

public class TagMapper : Profile
{
    public TagMapper()
    {
        CreateMap<TagCreateUpdateDto, Tag>();
    }
}