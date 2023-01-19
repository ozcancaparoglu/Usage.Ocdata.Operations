using AutoMapper;
using MediatR;
using Ocdata.Operations.Helpers.ResponseHelper;
using Usage.Application.ApiContracts.Queries;
using Usage.Application.Services;

namespace Usage.Application.Features.Categories.Queries.ListCategories
{
    public class ListCategoriesQueryHandler : IRequestHandler<ListCategoriesQuery, Result<List<CategoryResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public ListCategoriesQueryHandler(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        public async Task<Result<List<CategoryResponse>>> Handle(ListCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await Result<List<CategoryResponse>>.SuccessAsync(_mapper.Map<List<CategoryResponse>>(await _categoryService.List()));
        }
    }
}
