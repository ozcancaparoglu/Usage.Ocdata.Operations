using MediatR;
using Ocdata.Operations.Helpers.ResponseHelper;
using Usage.Application.ApiContracts.Queries;

namespace Usage.Application.Features.Categories.Queries.CategoryTree
{
    public class CategoryTreeQuery : IRequest<Result<List<CategoryTreeResponse>>>
    {
    }
}
