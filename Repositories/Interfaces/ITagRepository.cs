using Home_app.Models.Calendar;

namespace Home_app.Repositories.Interfaces;

public interface ITagRepository
{
    Task<IEnumerable<Tag?>> GetAllTags();
    Task<Tag?> GetTagById(Guid id);
    Tag? CreateTag(Tag tag);

    Tag? UpdateTag(Tag tag);
    Tag? DeleteTag(Tag tag);
}