using MediatR;
using Ocdata.Operations.Helpers.ResponseHelper;

namespace Usage.Application.Features.Categories.Commands.SaveCategory
{
    public class SaveCategoryCommand : IRequest<Result<string>>
    {
        public int? ParentId { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }
    }
}
