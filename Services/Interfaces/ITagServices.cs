using Home_app.Models.Calendar;
using Home_app.Models.Calendar.Dto;

namespace Home_app.Services.Interfaces;

public interface ITagServices
{
    Tag? CreateTag(TagCreateUpdateDto tagCreateUpdateDto);
    Task<IEnumerable<Tag?>> GetAllTags();
    Task<Tag?> GetTagById(Guid id);
    Task<Tag?> UpdateTag(Guid id, TagCreateUpdateDto tagCreateUpdateDto);
    Task<Tag?> DeleteTag(Guid id);
}