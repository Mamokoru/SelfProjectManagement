using FluentValidation;
using TaskFlow.API.DTOs;

namespace TaskFlow.API.Validators
{
    public class CreateProjectDtoValidator : AbstractValidator<CreateProjectDto>
    {
        public CreateProjectDtoValidator()
        {
            RuleFor(x => x.Name).
                NotNull().WithMessage("Project name is required.").NotEmpty().WithMessage("Project name is required.").
                MinimumLength(3).WithMessage("Project name must be at least 3 characters.").
                MaximumLength(100).WithMessage("Project name must not exceed 100 characters.");
        }
    }
}
