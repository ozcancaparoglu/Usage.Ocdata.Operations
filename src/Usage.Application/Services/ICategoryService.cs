using Usage.Application.Dtos;
using Usage.Domain.CategoryAggregate;

namespace Usage.Application.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ChildCategories(int parentId);
        Task<IEnumerable<Category>> List();
        Task<Category?> Save(CategoryDto dto);
        Task<Category?> Update(CategoryDto dto);
    }
}