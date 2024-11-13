using Home_app.DBContext;
using Home_app.Repositories.Interfaces;

namespace Home_app.Repositories;

public class RepositoryWrapper : IRepositoryWrapper
{
    private IEventRepository? _event;
    private ITagRepository? _tag;
    private IHealthRecordRepository? _health;
    
    private readonly HomeAppContext _context;

    public RepositoryWrapper(HomeAppContext context)
    {
        _context = context;
    }

    public IEventRepository Event => _event ??= new EventRepository(_context);
    public ITagRepository Tag => _tag ??= new TagRepository(_context);
    public IHealthRecordRepository Health => _health ??= new HealthRecordRepository(_context);
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}