using Home_app.Models.Health;

namespace Home_app.Repositories.Interfaces;

public interface IHealthRecordRepository
{
    Task<IEnumerable<HealthRecord?>> GetAllRecords();
    Task<IEnumerable<Measurement?>> GetAllMeasurements();
    Task<IEnumerable<Lift?>> GetAllLifts();
    Task<HealthRecord?> GetRecordById(Guid id);
    Task<HealthRecord?> GetRecordByDate(DateOnly date);
    Task<Measurement?> GetMeasurementById(Guid id);
    Task<Lift?> GetLiftById(Guid id);
    HealthRecord? CreateRecord(HealthRecord healthRecord);
    HealthRecord? UpdateRecord(HealthRecord healthRecord);
    HealthRecord? DeleteRecord(HealthRecord healthRecord);
}