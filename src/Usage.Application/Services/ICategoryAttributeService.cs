using Usage.Application.Dtos;
using Usage.Domain.CategoryAggregate;

namespace Usage.Application.Services
{
    public interface ICategoryAttributeService
    {
        Task<CategoryAttribute?> Save(CategoryAttributeDto dto);
        Task<CategoryAttribute?> Update(CategoryAttributeDto dto);
    }
}