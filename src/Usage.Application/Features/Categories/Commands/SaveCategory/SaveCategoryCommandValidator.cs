using FluentValidation;

namespace Usage.Application.Features.Categories.Commands.SaveCategory
{
    public class SaveCategoryCommandValidator : AbstractValidator<SaveCategoryCommand>
    {
        public SaveCategoryCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{Name} must not be over 250 characters.");

            RuleFor(p => p.DisplayName)
                .NotEmpty().WithMessage("{DisplayName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{DisplayName} must not be over 250 characters.");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{Description} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{Description} must not be over 250 characters.");
        }
    }
}
