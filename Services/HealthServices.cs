using AutoMapper;
using Home_app.Models.Health;
using Home_app.Models.Health.Dto;
using Home_app.Repositories.Interfaces;
using Home_app.Services.Interfaces;
using Serilog;

namespace Home_app.Services;

public class HealthServices : IHealthServices
{
    private readonly IHealthRecordRepository _healthRecordRepository;
    private readonly IMapper _mapper;

    public HealthServices(IHealthRecordRepository healthRecordRepository, IMapper mapper)
    {
        _healthRecordRepository = healthRecordRepository;
        _mapper = mapper;
    }
    
    
    public async Task<HealthRecord?> CreateRecord(RecordCreateDto recordCreateDto)
    {
        if (recordCreateDto == null)
        {
            Log.Information("Health record not created");
            return null;
        }

        var record = _mapper.Map<HealthRecord>(recordCreateDto);
        return await _healthRecordRepository.CreateRecord(record);
    }

    public async Task<HealthRecord?> AddMeasurement(Guid id, MeasurementCreateDto measurementCreateDto)
    {
        var record = await _healthRecordRepository.GetRecordById(id);
        
        if (measurementCreateDto == null || record == null)
        {
            return null;
        }

        var measurement = _mapper.Map<Measurement>(measurementCreateDto);
        record.Measurements?.Add(measurement);

        return await _healthRecordRepository.UpdateRecord(record);
    }

    public async Task<HealthRecord?> AddLift(Guid id, LiftCreateDto liftCreateDto)
    {
        var record = await _healthRecordRepository.GetRecordById(id);
        
        if (liftCreateDto == null || record == null)
        {
            return null;
        }

        var lift = _mapper.Map<Lift>(liftCreateDto);
        record.Lifts?.Add(lift);

        return await _healthRecordRepository.UpdateRecord(record);
    }

    public async Task<IEnumerable<HealthRecord?>> GetAllRecords()
    {
        return await _healthRecordRepository.GetAllRecords();
    }

    public async Task<IEnumerable<Measurement?>> GetAllMeasurements()
    {
        return await _healthRecordRepository.GetAllMeasurements();
    }

    public async Task<IEnumerable<Lift?>> GetAllLifts()
    {
        return await _healthRecordRepository.GetAllLifts();
    }

    public async Task<HealthRecord?> GetRecordById(Guid id)
    {
        return await _healthRecordRepository.GetRecordById(id);
    }

    public async Task<HealthRecord?> UpdateRecord(Guid id, RecordCreateDto healthRecord)
    {
        var record = await _healthRecordRepository.GetRecordById(id);
        
        if (record == null || healthRecord == null)
        {
            return null;
        }

        _mapper.Map(healthRecord, record);
        return await _healthRecordRepository.UpdateRecord(record);
    }

    public async Task<HealthRecord?> DeleteRecord(Guid id)
    {
        var record = await _healthRecordRepository.GetRecordById(id);

        if (record == null)
        {
            return null;
        }

        return await _healthRecordRepository.DeleteRecord(record);
    }

    public async Task<HealthRecord?> DeleteMeasurement(Guid recordId, Guid measurementId)
    {
        var record = await _healthRecordRepository.GetRecordById(recordId);
        var measurement = await _healthRecordRepository.GetMeasurementById(measurementId);
        
        if (record == null || measurement == null)
        {
            return null;
        }

        record.Measurements!.Remove(measurement);

        return await _healthRecordRepository.UpdateRecord(record);
    }

    public async Task<HealthRecord?> DeleteLift(Guid recordId, Guid liftId)
    {
        var record = await _healthRecordRepository.GetRecordById(recordId);
        var lift = await _healthRecordRepository.GetLiftById(liftId);
        
        if (record == null || lift == null)
        {
            return null;
        }

        record.Lifts!.Remove(lift);

        return await _healthRecordRepository.UpdateRecord(record);
    }
    
}