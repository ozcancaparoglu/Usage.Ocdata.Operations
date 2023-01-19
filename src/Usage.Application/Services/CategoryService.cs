using AutoMapper;
using Ocdata.Operations.Cache;
using Ocdata.Operations.Helpers.ResponseHelper;
using Ocdata.Operations.Repositories.Contracts;
using Usage.Application.Cache;
using Usage.Application.Dtos;
using Usage.Application.Services.BaseServices;
using Usage.Domain.CategoryAggregate;

namespace Usage.Application.Services
{
    public class CategoryService : CrudBaseService<Category, CategoryDto>, ICategoryService
    {
        private readonly string _cacheKey;
        private readonly int _cacheTime;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, ICacheService cacheService) 
            : base(unitOfWork, mapper, cacheService)
        {
            _cacheKey = CacheConstants.CategoryCacheKey;
            _cacheTime = CacheConstants.CategoryCacheTime;
        }

        #region Entity Crud

        public async Task<IEnumerable<Category>> List() => await List(new PagerInput(), all: true, cacheKey: _cacheKey, cacheTime: _cacheTime);
        public async Task<Category?> Save(CategoryDto dto) => await Save(dto, filter: x => x.Name == dto.Name && x.DisplayName == dto.DisplayName, cacheKey: _cacheKey);
        public async Task<Category?> Update(CategoryDto dto)
        {
            var entity = await _unitOfWork.Repository<Category>().GetById(dto.Id);

            if (entity == null)
                return null;

            entity.SetCategory(dto.ParentId, dto.Name, dto.DisplayName, dto.Description);

            return await Update(entity, cacheKey: _cacheKey);
        }
        public async Task<bool> Delete(CategoryDto dto) => await Delete(dto, cacheKey: _cacheKey);

        #endregion

        public async Task<IEnumerable<Category>> ChildCategories(int parentId)
        {
            var subCategories = AllEntities.Where(x => x.ParentId == parentId);

            foreach (var subCategory in subCategories)
            {
                subCategory.SubCategories.AddRange(await ChildCategories(subCategory.Id));
            }

            return subCategories;
        }
    }
}
