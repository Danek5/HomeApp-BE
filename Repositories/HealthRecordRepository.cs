using Home_app.DBContext;
using Home_app.Models.Health;
using Home_app.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Home_app.Repositories;

public class HealthRecordRepository : IHealthRecordRepository
{
    private readonly HomeAppContext _homeAppContext;

    public HealthRecordRepository(HomeAppContext homeAppContext)
    {
        _homeAppContext = homeAppContext;
    }


    public async Task<HealthRecord?> CreateRecord(HealthRecord healthRecord)
    {
        await _homeAppContext.HealthRecords.AddAsync(healthRecord);
        await _homeAppContext.SaveChangesAsync();
        return healthRecord;
    }

    public async Task<IEnumerable<HealthRecord?>> GetAllRecords()
    {
        return await _homeAppContext.HealthRecords.Include(m => m.Measurements).Include(r => r.Lifts).ToListAsync();
    }

    public async Task<IEnumerable<Measurement?>> GetAllMeasurements()
    {
        return await _homeAppContext.HealthRecords.SelectMany(m => m.Measurements!).ToListAsync();
    }

    public async Task<IEnumerable<Lift?>> GetAllLifts()
    {
        return await _homeAppContext.HealthRecords.SelectMany(l => l.Lifts!).ToListAsync();
    }

    public async Task<HealthRecord?> GetRecordById(Guid id)
    {
        return await _homeAppContext.HealthRecords.Include(r => r.Measurements).Include(r => r.Lifts)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<Measurement?> GetMeasurementById(Guid id)
    {
        return await _homeAppContext.HealthRecords.SelectMany(r => r.Measurements!)
            .FirstOrDefaultAsync(m => m.Id == id);
    }


    public async Task<Lift?> GetLiftById(Guid id)
    {
        return await _homeAppContext.HealthRecords.SelectMany(l => l.Lifts!)
            .FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<HealthRecord?> UpdateRecord(HealthRecord healthRecords)
    {
        _homeAppContext.HealthRecords.Update(healthRecords);
        await _homeAppContext.SaveChangesAsync();
        return healthRecords;
    }

    public async Task<HealthRecord?> DeleteRecord(HealthRecord healthRecords)
    {
        _homeAppContext.HealthRecords.Remove(healthRecords);
        await _homeAppContext.SaveChangesAsync();
        return healthRecords;
    }
}