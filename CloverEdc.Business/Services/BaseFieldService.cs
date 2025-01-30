using CloverEdc.Business.Helpers;
using CloverEdc.Business.Interfaces;
using CloverEdc.Core.DTOs;
using CloverEdc.Core.Interfaces;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Services;
public class BaseFieldService : IBaseFieldService
{
    private readonly IBaseFieldRepository _baseFieldRepository;
    private readonly IDropDownOptionRepository _dropDownOptionRepository;

    public BaseFieldService(IBaseFieldRepository baseFieldRepository, IDropDownOptionRepository dropDownOptionRepository)
    {
        _baseFieldRepository = baseFieldRepository;
        _dropDownOptionRepository = dropDownOptionRepository;
    }

    public async Task<IEnumerable<BaseField>> GetBaseFieldsByCrfTemplateIdAsync(Guid crfTemplateId)
    {
        return await _baseFieldRepository.GetByCrfTemplateIdAsync(crfTemplateId);
    }

    public async Task<BaseField> CreateBaseFieldAsync(string name, Guid typeId, Guid crfTemplateId, List<string>? options = null)
    {
        var baseField = new BaseField
        {
            FieldName = name,
            TypeId = typeId,
            CrfTemplateId = crfTemplateId,
        };
        var baseFieldExist = await _baseFieldRepository.AddAsync(baseField);

        if (options != null && options.Any())
        {   
            // baseField.DropDownOptions = options.Select(o => new DropDownOption
            // {
            //     Id = Guid.NewGuid(),
            //     BaseFieldId = baseField.Id,
            //     Value = o
            // }).ToList();
            foreach (var option in options)
            {
                await _dropDownOptionRepository.AddAsync(new DropDownOption
                {
                    BaseFieldId = baseField.Id,
                    Value = option
                });
                
            }
        }

        return baseFieldExist;
    }
    public async Task<BaseField> GetBaseFieldByIdAsync(Guid id)
    {
        return await _baseFieldRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<BaseField>> GetAllBaseFieldsAsync()
    {
        return await _baseFieldRepository.GetAllAsync();
    }
}
