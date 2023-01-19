using FluentValidation;

namespace Usage.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{Id} is required.")
                .NotNull();

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
