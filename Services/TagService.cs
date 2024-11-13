using AutoMapper;
using Home_app.Models.Calendar;
using Home_app.Models.Calendar.Dto;
using Home_app.Repositories.Interfaces;
using Home_app.Services.Interfaces;

namespace Home_app.Services;

public class TagService : ITagServices
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;

    public TagService(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Tag?> CreateTag(TagCreateUpdateDto tagCreateUpdateDto)
    {
        if (tagCreateUpdateDto == null)
        {
            return null;
        }

        var tagCreate = _mapper.Map<Tag>(tagCreateUpdateDto);
        var tag = _repository.Tag.CreateTag(tagCreate);

        await _repository.SaveAsync();
        return tag;
    }

    public async Task<IEnumerable<Tag?>> GetAllTags()
    {
        return await _repository.Tag.GetAllTags();
    }

    public async Task<Tag?> GetTagById(Guid id)
    {
        return await _repository.Tag.GetTagById(id);
    }

    public async Task<Tag?> UpdateTag(Guid id, TagCreateUpdateDto tagCreateUpdateDto)
    {
        var tagUpdate = await _repository.Tag.GetTagById(id);

        if (tagUpdate == null || tagCreateUpdateDto == null)
        {
            return null;
        }

        _mapper.Map(tagCreateUpdateDto, tagUpdate);
        return _repository.Tag.UpdateTag(tagUpdate);
    }
    
    public async Task<Tag?> DeleteTag(Guid id)
    {
        var tagToDelete = await _repository.Tag.GetTagById(id);

        var tag = _repository.Tag.DeleteTag(tagToDelete ?? throw new InvalidOperationException());
    
        await _repository.SaveAsync();
        return _repository.Tag.DeleteTag(tag!);
    }
}