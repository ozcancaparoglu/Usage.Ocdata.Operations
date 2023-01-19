using MediatR;
using Ocdata.Operations.Enums;
using Ocdata.Operations.Helpers.ResponseHelper;

namespace Usage.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<Result<string>>
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public State State { get; set; }
    }
}
