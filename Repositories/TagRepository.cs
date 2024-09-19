using Home_app.DBContext;
using Home_app.Models.Calendar;
using Home_app.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Home_app.Repositories;

public class TagRepository : ITagRepository
{
    private readonly HomeAppContext _homeAppContext;

    public TagRepository(HomeAppContext homeAppContext)
    {
        _homeAppContext = homeAppContext;
    }

    public async Task<Tag?> CreateTag(Tag tag)
    {
        await _homeAppContext.AddAsync(tag);
        await _homeAppContext.SaveChangesAsync();
        return tag;
    }


    public async Task<IEnumerable<Tag?>> GetAllTags()
    {
        return await _homeAppContext.Tags.ToListAsync();
    }

    public async Task<Tag?> GetTagById(Guid id)
    {
        return await _homeAppContext.Tags.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Tag?> UpdateTag(Tag tag)
    {
        _homeAppContext.Tags.Update(tag);
        await _homeAppContext.SaveChangesAsync();
        return tag;
    }

    public async Task<Tag?> DeleteTag(Tag tag)
    {
        _homeAppContext.Tags.Remove(tag);
        await _homeAppContext.SaveChangesAsync();
        return tag;
    }
    
}