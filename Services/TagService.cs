using AutoMapper;
using Home_app.Models.Calendar;
using Home_app.Models.Calendar.Dto;
using Home_app.Repositories.Interfaces;
using Home_app.Services.Interfaces;

namespace Home_app.Services;

public class TagService : ITagServices
{
    private readonly ITagRepository _tagRepository;
    private readonly IMapper _mapper;

    public TagService(ITagRepository tagRepository, IMapper mapper)
    {
        _tagRepository = tagRepository;
        _mapper = mapper;
    }


    public async Task<Tag?> CreateTag(TagCreateUpdateDto tagCreateUpdateDto)
    {
        if (tagCreateUpdateDto == null)
        {
            return null;
        }

        var tagCreate = _mapper.Map<Tag>(tagCreateUpdateDto);
        return await _tagRepository.CreateTag(tagCreate);
    }

    public async Task<IEnumerable<Tag?>> GetAllTags()
    {
        return await _tagRepository.GetAllTags();
    }

    public async Task<Tag?> GetTagById(Guid id)
    {
        return await _tagRepository.GetTagById(id);
    }

    public async Task<Tag?> UpdateTag(Guid id, TagCreateUpdateDto tagCreateUpdateDto)
    {
        var tagUpdate = await _tagRepository.GetTagById(id);

        if (tagUpdate == null || tagCreateUpdateDto == null)
        {
            return null;
        }

        _mapper.Map(tagCreateUpdateDto, tagUpdate);
        return await _tagRepository.UpdateTag(tagUpdate);
    }



    public async Task<Tag?> DeleteTag(Guid id)
    {
        var even = await _tagRepository.GetTagById(id);
        return await _tagRepository.DeleteTag(even!);
    }
}