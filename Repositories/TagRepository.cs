using Home_app.DBContext;
using Home_app.Models.Calendar;
using Home_app.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Home_app.Repositories;

public class TagRepository : RepositoryBase<Tag>, ITagRepository
{
    public TagRepository(HomeAppContext context) : base(context)
    {
    }

    public Tag? CreateTag(Tag tag)
    {
        return Create(tag);
    }


    public async Task<IEnumerable<Tag?>> GetAllTags()
    {
        return await GetAll().ToListAsync();
    }

    public async Task<Tag?> GetTagById(Guid id)
    {
        return await GetByCondition(t => t.Id == id).FirstOrDefaultAsync();
    }

    public Tag? UpdateTag(Tag tag)
    {
        return Update(tag);
    }

    public Tag? DeleteTag(Tag tag)
    {
        return Delete(tag);
    }
    
}