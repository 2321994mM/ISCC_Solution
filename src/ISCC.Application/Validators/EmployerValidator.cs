using FluentValidation;
using ISCC.Application.DTOs;

namespace ISCC.Application.Validators;

public class CreateEmployerRequestValidator : AbstractValidator<CreateEmployerRequest>
{
    public CreateEmployerRequestValidator()
    {
        RuleFor(x => x.CompanyName)
            .NotEmpty().WithMessage("Company name is required")
            .MaximumLength(200);

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format")
            .MaximumLength(200);

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Phone is required")
            .MaximumLength(20);

        RuleFor(x => x.CommercialRegistration)
            .NotEmpty().WithMessage("Commercial registration is required")
            .MaximumLength(50);
    }
}
