namespace Home_app.Repositories.Interfaces;

public interface IRepositoryWrapper
{
    IEventRepository Event { get; }
    ITagRepository Tag { get; }
    IHealthRecordRepository Health { get; }
    Task<int> SaveAsync();
}