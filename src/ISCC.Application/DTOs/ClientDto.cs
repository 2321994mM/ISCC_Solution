namespace ISCC.Application.DTOs;

public record ClientDto(
    int Id,
    string Name,
    string Email,
    string Phone,
    string Address,
    string NationalId
);

public record CreateClientRequest(
    string Name,
    string Email,
    string Phone,
    string Address,
    string NationalId
);
