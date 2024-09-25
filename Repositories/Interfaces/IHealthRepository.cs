using Home_app.Models.Health;

namespace Home_app.Repositories.Interfaces;

public interface IHealthRecordRepository
{
    Task<HealthRecord?> CreateRecord(HealthRecord healthRecord);
    Task<IEnumerable<HealthRecord?>> GetAllRecords();
    Task<IEnumerable<Measurement?>> GetAllMeasurements();
    Task<IEnumerable<Lift?>> GetAllLifts();
    Task<HealthRecord?> GetRecordById(Guid id);
    Task<Measurement?> GetMeasurementById(Guid id);
    Task<Lift?> GetLiftById(Guid id);
    Task<HealthRecord?> UpdateRecord(HealthRecord healthRecord);
    Task<HealthRecord?> DeleteRecord(HealthRecord healthRecord);
}