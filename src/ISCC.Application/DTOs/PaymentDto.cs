namespace ISCC.Application.DTOs;

public record PaymentDto(
    int Id,
    string PaymentNumber,
    decimal Amount,
    DateTime PaymentDate,
    string Status,
    string? Description
);

public record CreatePaymentRequest(
    string PaymentNumber,
    decimal Amount,
    DateTime PaymentDate,
    string? Description,
    int? ClientId,
    int? EmployerId
);
