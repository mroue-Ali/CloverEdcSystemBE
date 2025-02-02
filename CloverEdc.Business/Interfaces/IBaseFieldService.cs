using CloverEdc.Core.DTOs;
using CloverEdc.Core.Models;

namespace CloverEdc.Business.Interfaces;

public interface IBaseFieldService
{
    Task<IEnumerable<BaseField>> GetBaseFieldsByCrfTemplateIdAsync(Guid crfTemplateId);
    Task<BaseField> CreateBaseFieldAsync(string name, Guid typeId, Guid crfTemplateId, List<string>? options = null);

    Task<BaseField> GetBaseFieldByIdAsync(Guid id);
    Task<IEnumerable<BaseField>> GetAllBaseFieldsAsync();
}
