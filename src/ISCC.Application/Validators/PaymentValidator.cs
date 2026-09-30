using FluentValidation;
using ISCC.Application.DTOs;

namespace ISCC.Application.Validators;

public class CreatePaymentRequestValidator : AbstractValidator<CreatePaymentRequest>
{
    public CreatePaymentRequestValidator()
    {
        RuleFor(x => x.PaymentNumber)
            .NotEmpty().WithMessage("Payment number is required")
            .MaximumLength(50);

        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Amount must be greater than zero");

        RuleFor(x => x.PaymentDate)
            .NotEmpty().WithMessage("Payment date is required");

        RuleFor(x => x.Description)
            .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.Description));
    }
}
