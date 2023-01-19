using FluentValidation;

namespace Usage.Application.Features.CategoryAttributes.Commands.SaveCategoryAttribute
{
    public class SaveCategoryAttributeCommandValidator : AbstractValidator<SaveCategoryAttributeCommand>
    {
        public SaveCategoryAttributeCommandValidator()
        {
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
