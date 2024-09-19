using Home_app.Models.Calendar;

namespace Home_app.Repositories.Interfaces;

public interface ITagRepository
{
    Task<Tag?> CreateTag(Tag tag);
    Task<IEnumerable<Tag?>> GetAllTags();
    Task<Tag?> GetTagById(Guid id);
    Task<Tag?> UpdateTag(Tag tag);
    Task<Tag?> DeleteTag(Tag tag);
}