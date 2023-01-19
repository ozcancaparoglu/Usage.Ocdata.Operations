using MediatR;
using Ocdata.Operations.Helpers.ResponseHelper;
using Usage.Application.ApiContracts.Queries;

namespace Usage.Application.Features.Categories.Queries.ListCategories
{
    public class ListCategoriesQuery : IRequest<Result<List<CategoryResponse>>>
    {
    }
}
