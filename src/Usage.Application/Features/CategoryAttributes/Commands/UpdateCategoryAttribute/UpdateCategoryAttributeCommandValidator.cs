using FluentValidation;

namespace Usage.Application.Features.CategoryAttributes.Commands.UpdateCategoryAttribute
{
    public class UpdateCategoryAttributeCommandValidator : AbstractValidator<UpdateCategoryAttributeCommand>
    {
        public UpdateCategoryAttributeCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{Id} is required.")
                .NotNull();

            RuleFor(p => p.CategoryId)
                .NotEmpty().WithMessage("{CategoryId} field is required.")
                .NotNull();

            RuleFor(p => p.AttributeId)
                .NotEmpty().WithMessage("{AttributeId} field is required.")
                .NotNull();

            RuleFor(p => p.IsRequired)
                .NotEmpty().WithMessage("{IsRequired} field is required.:)")
                .NotNull();

            RuleFor(p => p.IsVariantable)
                .NotEmpty().WithMessage("{IsVariantable} field is required.")
                .NotNull();
        }
    }
}
