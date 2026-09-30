using FluentValidation;
using ISCC.Application.DTOs;

namespace ISCC.Application.Validators;

public class CreateInspectionRequestValidator : AbstractValidator<CreateInspectionRequest>
{
    public CreateInspectionRequestValidator()
    {
        RuleFor(x => x.InspectionNumber)
            .NotEmpty().WithMessage("Inspection number is required")
            .MaximumLength(50);

        RuleFor(x => x.InspectionDate)
            .NotEmpty().WithMessage("Inspection date is required");

        RuleFor(x => x.Notes)
            .MaximumLength(1000).When(x => !string.IsNullOrEmpty(x.Notes));
    }
}
