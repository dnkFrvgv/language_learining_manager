using FluentValidation;
namespace Application.DTO
{
  public class LearningSpaceDtoValidator : AbstractValidator<LearningSpaceDto>
  {
    public LearningSpaceDtoValidator()
    {
      RuleFor(s=>s.Title).NotEmpty();
      RuleFor(s=>s.Description).MaximumLength(150).WithMessage("Description can't have more than 150 caracters.");
      RuleFor(s=>s.LanguageId).NotEmpty();
      RuleFor(s=>s.StartDate).NotEmpty();
      RuleFor(s=>s.StartDate).Must(date => !date.Equals(default(DateOnly))).WithMessage("StartDate can't be in the future.");
    }
  }
}