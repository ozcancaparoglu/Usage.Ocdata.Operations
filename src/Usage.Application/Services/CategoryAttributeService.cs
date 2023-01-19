using AutoMapper;
using Ocdata.Operations.Cache;
using Ocdata.Operations.Repositories.Contracts;
using Usage.Application.Cache;
using Usage.Application.Dtos;
using Usage.Application.Services.BaseServices;
using Usage.Domain.CategoryAggregate;

namespace Usage.Application.Services
{
    public class CategoryAttributeService : CrudBaseService<CategoryAttribute, CategoryAttributeDto>, ICategoryAttributeService
    {
        private readonly string _cacheKey;
        private readonly int _cacheTime;

        public CategoryAttributeService(IUnitOfWork unitOfWork, IMapper mapper, ICacheService cacheService)
            : base(unitOfWork, mapper, cacheService)
        {
            _cacheKey = CacheConstants.CategoryAttributesCacheKey;
            _cacheTime = CacheConstants.CategoryAttributesCacheTime;
        }

        #region Entity Crud 

        public async Task<CategoryAttribute?> Save(CategoryAttributeDto dto) => await Save(dto,
            filter: x => x.CategoryId == dto.CategoryId && x.AttributeId == dto.AttributeId,
            cacheKey: _cacheKey);

        public async Task<CategoryAttribute?> Update(CategoryAttributeDto dto)
        {
            var entity = await _unitOfWork.Repository<CategoryAttribute>().GetById(dto.Id);

            if (entity == null)
                return null;

            entity.SetCategoryAttribute(dto.CategoryId, dto.AttributeId, dto.IsRequired, dto.IsVariantable);

            return await Update(dto);
        }

        #endregion
    }
}
