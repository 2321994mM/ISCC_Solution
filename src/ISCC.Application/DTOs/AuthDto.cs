namespace ISCC.Application.DTOs;

public record LoginRequest(string Username, string Password);

public record LoginResponse(
    int UserId,
    string Username,
    string FullName,
    string Role,
    string Token
);

public record DashboardDto(
    int TotalClients,
    int TotalEmployers,
    int TotalPayments,
    decimal TotalRevenue,
    int TotalInspections,
    int TotalCertificates
);
