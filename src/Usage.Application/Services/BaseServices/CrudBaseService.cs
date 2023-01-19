using AutoMapper;
using Ocdata.Operations.Cache;
using Ocdata.Operations.Entities;
using Ocdata.Operations.Enums;
using Ocdata.Operations.Helpers.ResponseHelper;
using Ocdata.Operations.Repositories.Contracts;
using System.Linq.Expressions;
using Usage.Application.Dtos.Common;

namespace Usage.Application.Services.BaseServices
{
    public abstract class CrudBaseService<TEntity, TDto>
        where TEntity : EntityBase
        where TDto : DtoBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly ICacheService _cacheService;

        private List<TEntity> _allEntities;
        public List<TEntity> AllEntities
        {
            get { return _allEntities; }
            set { _allEntities = value; }
        }

        public CrudBaseService(IUnitOfWork unitOfWork, IMapper mapper, ICacheService cacheService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
            _allEntities = new List<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> List(PagerInput pagerInput, bool all = false, string? cacheKey = null, int cacheTime = 0)
        {
            if (!all)
                return await _unitOfWork.Repository<TEntity>().Filter(x => x.State == (int)State.Active, pagerInput.PageIndex, pagerInput.PageSize);

            if (all && !_cacheService.TryGetValue(cacheKey, out _allEntities))
            {
                AllEntities = (List<TEntity>)await _unitOfWork.Repository<TEntity>().GetAll();
                _cacheService.Add(cacheKey, AllEntities, cacheTime);
            }

            return AllEntities;
        }

        public async Task<TEntity?> Save(TDto dto, Expression<Func<TEntity, bool>> filter, string? cacheKey = null)
        {
            var existing = await _unitOfWork.Repository<TEntity>().Find(filter);

            if (existing != null)
                return null;

            var entity = _mapper.Map<TEntity>(dto);

            await _unitOfWork.Repository<TEntity>().Add(entity);

            if (!string.IsNullOrWhiteSpace(cacheKey))
                _cacheService.Remove(cacheKey);

            await _unitOfWork.CommitAsync();

            return entity;
        }

        public async Task<TEntity?> Update(TEntity entity, string? cacheKey = null)
        {
            _unitOfWork.Repository<TEntity>().Update(entity);

            if (!string.IsNullOrWhiteSpace(cacheKey))
                _cacheService.Remove(cacheKey);

            await _unitOfWork.CommitAsync();

            return entity;
        }

        public async Task<bool> Delete(TDto dto, string? cacheKey = null)
        {
            var entity = await _unitOfWork.Repository<TEntity>().GetById(dto.Id);

            if (entity == null)
                return false;

            entity.Delete();

            _unitOfWork.Repository<TEntity>().Update(entity);

            if (!string.IsNullOrWhiteSpace(cacheKey))
                _cacheService.Remove(cacheKey);

            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}
