using AutoMapper;
using MediatR;
using Ocdata.Operations.Helpers.ResponseHelper;
using Usage.Application.ApiContracts.Queries;
using Usage.Application.Services;

namespace Usage.Application.Features.Categories.Queries.CategoryTree
{
    public class CategoryTreeHandler : IRequestHandler<CategoryTreeQuery, Result<List<CategoryTreeResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CategoryTreeHandler(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        public async Task<Result<List<CategoryTreeResponse>>> Handle(CategoryTreeQuery request, CancellationToken cancellationToken)
        {

            var allCategories = await _categoryService.List();
            var mainCategories = allCategories.Where(x => x.ParentId == null).ToList();

            foreach (var mainCategory in mainCategories)
            {
                mainCategory.SubCategories.AddRange(await _categoryService.ChildCategories(mainCategory.Id));
            }

            return await Result<List<CategoryTreeResponse>>.SuccessAsync(_mapper.Map<List<CategoryTreeResponse>>(mainCategories));
        }
    }
}
