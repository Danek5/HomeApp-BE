using AutoMapper;
using Home_app.Models.Health;
using Home_app.Models.Health.Dto;
using Home_app.Repositories.Interfaces;
using Home_app.Services.Interfaces;
using Serilog;

namespace Home_app.Services;

public class HealthServices : IHealthServices
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;

    public HealthServices(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    
    public async Task<HealthRecord?> CreateRecord(RecordCreateDto recordCreateDto)
    {
        if (recordCreateDto == null)
        {
            Log.Information("Health record not created");
            return null;
        }

        var recordToCreate = _mapper.Map<HealthRecord>(recordCreateDto);
        var record = _repository.Health.CreateRecord(recordToCreate);

        await _repository.SaveAsync();
        return record;
    }

    public async Task<HealthRecord?> AddMeasurement(Guid id, MeasurementCreateDto measurementCreateDto)
    {
        var record = await _repository.Health.GetRecordById(id);
        
        if (measurementCreateDto == null || record == null)
        {
            return null;
        }

        var measurement = _mapper.Map<Measurement>(measurementCreateDto);
        record.Measurements?.Add(measurement);
        var recordResult = _repository.Health.UpdateRecord(record);

        await _repository.SaveAsync();
        return recordResult;
    }

    public async Task<HealthRecord?> AddLift(Guid id, LiftCreateDto liftCreateDto)
    {
        var record = await _repository.Health.GetRecordById(id);
        
        if (liftCreateDto == null || record == null)
        {
            return null;
        }

        var lift = _mapper.Map<Lift>(liftCreateDto);
        record.Lifts?.Add(lift);
        var recordResult = _repository.Health.UpdateRecord(record);

        await _repository.SaveAsync();
        return recordResult;
    }

    public async Task<IEnumerable<HealthRecord?>> GetAllRecords()
    {
        return await _repository.Health.GetAllRecords();
    }

    public async Task<IEnumerable<Measurement?>> GetAllMeasurements()
    {
        return await _repository.Health.GetAllMeasurements();
    }

    public async Task<IEnumerable<Lift?>> GetAllLifts()
    {
        return await _repository.Health.GetAllLifts();
    }

    public async Task<HealthRecord?> GetRecordById(Guid id)
    {
        return await _repository.Health.GetRecordById(id);
    }

    public async Task<HealthRecord?> UpdateRecord(Guid id, RecordCreateDto healthRecord)
    {
        var record = await _repository.Health.GetRecordById(id);
        
        if (record == null || healthRecord == null)
        {
            return null;
        }

        _mapper.Map(healthRecord, record);
        var recordResult = _repository.Health.UpdateRecord(record);

        await _repository.SaveAsync();
        return recordResult;
    }

    public async Task<HealthRecord?> DeleteRecord(Guid id)
    {
        var record = await _repository.Health.GetRecordById(id);

        if (record == null)
        {
            return null;
        }

        var recordResult = _repository.Health.DeleteRecord(record);

        await _repository.SaveAsync();
        return recordResult;
    }

    public async Task<HealthRecord?> DeleteMeasurement(Guid recordId, Guid measurementId)
    {
        var record = await _repository.Health.GetRecordById(recordId);
        var measurement = await _repository.Health.GetMeasurementById(measurementId);
        
        if (record == null || measurement == null)
        {
            return null;
        }

        record.Measurements!.Remove(measurement);

        var recordResult = _repository.Health.DeleteRecord(record);

        await _repository.SaveAsync();
        return recordResult;
    }

    public async Task<HealthRecord?> DeleteLift(Guid recordId, Guid liftId)
    {
        var record = await _repository.Health.GetRecordById(recordId);
        var lift = await _repository.Health.GetLiftById(liftId);
        
        if (record == null || lift == null)
        {
            return null;
        }

        record.Lifts!.Remove(lift);

        var recordResult = _repository.Health.DeleteRecord(record);

        await _repository.SaveAsync();
        return recordResult;
    }
}