using Home_app.Models.Health;
using Home_app.Models.Health.Dto;

namespace Home_app.Services.Interfaces;

public interface IHealthServices
{
    Task<HealthRecord?> CreateRecord(RecordCreateDto recordCreateDto);
    Task<HealthRecord?> AddMeasurement(Guid id, MeasurementCreateDto measurementCreateDto);
    Task<HealthRecord?> AddLift(Guid id, LiftCreateDto liftCreateDto);
    Task<IEnumerable<HealthRecord?>> GetAllRecords();
    Task<IEnumerable<Measurement?>> GetAllMeasurements();
    Task<IEnumerable<Lift?>> GetAllLifts();
    Task<HealthRecord?> GetRecordById(Guid id);
    Task<HealthRecord?> UpdateRecord(Guid id, RecordCreateDto healthRecord);
    Task<HealthRecord?> DeleteRecord(Guid id);
    Task<HealthRecord?> DeleteMeasurement(Guid recordId, Guid measurementId);
    Task<HealthRecord?> DeleteLift(Guid recordId, Guid liftId);
}