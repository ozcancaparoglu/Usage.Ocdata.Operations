using MediatR;
using Ocdata.Operations.Helpers.ResponseHelper;

namespace Usage.Application.Features.CategoryAttributes.Commands.UpdateCategoryAttribute
{
    public class UpdateCategoryAttributeCommand : IRequest<Result<string>>
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int AttributeId { get; set; }
        public bool IsRequired { get; set; }
        public bool IsVariantable { get; set; }
    }
}
