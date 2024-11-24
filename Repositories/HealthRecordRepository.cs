using Home_app.DBContext;
using Home_app.Models.Health;
using Home_app.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Home_app.Repositories;

public class HealthRecordRepository : RepositoryBase<HealthRecord>, IHealthRecordRepository
{
    public HealthRecordRepository(HomeAppContext context) : base(context)
    {
    }


    public HealthRecord? CreateRecord(HealthRecord healthRecord)
    {
        return Create(healthRecord);
    }

    public async Task<IEnumerable<HealthRecord?>> GetAllRecords()
    {
        return await GetAll().ToListAsync();
    }

    public async Task<IEnumerable<Measurement?>> GetAllMeasurements()
    {
        return await GetAll()
            .SelectMany(healthRecord => healthRecord.Measurements!)
            .ToListAsync();
    }

    public async Task<IEnumerable<Lift?>> GetAllLifts()
    {
        return await GetAll().SelectMany(l => l.Lifts!).ToListAsync();
    }

    public async Task<HealthRecord?> GetRecordById(Guid id)
    {
        return await GetByCondition(r => r.Id == id).FirstOrDefaultAsync();
    }
    
    public async Task<HealthRecord?> GetRecordByDate(DateOnly date)
    {
        return await GetByCondition(r => r.Date == date).FirstOrDefaultAsync();
    }

    public async Task<Measurement?> GetMeasurementById(Guid id)
    {
        return await GetAll()
            .SelectMany(healthRecord => healthRecord.Measurements!)
            .FirstOrDefaultAsync(measurement => measurement.Id == id);
    }
    
    public async Task<Lift?> GetLiftById(Guid id)
    {
        return await GetAll()
            .SelectMany(healthRecord => healthRecord.Lifts!)
            .FirstOrDefaultAsync(lift => lift.Id == id);
    }

    public HealthRecord? UpdateRecord(HealthRecord healthRecords)
    {
        return Update(healthRecords);
    }

    public HealthRecord? DeleteRecord(HealthRecord healthRecords)
    {
        return Delete(healthRecords);
    }
}