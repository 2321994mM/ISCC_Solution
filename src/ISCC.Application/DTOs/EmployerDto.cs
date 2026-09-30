namespace ISCC.Application.DTOs;

public record EmployerDto(
    int Id,
    string CompanyName,
    string Email,
    string Phone,
    string Address,
    string CommercialRegistration
);

public record CreateEmployerRequest(
    string CompanyName,
    string Email,
    string Phone,
    string Address,
    string CommercialRegistration
);
