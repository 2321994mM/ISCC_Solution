namespace ISCC.Application.DTOs;

public record CertificateDto(
    int Id,
    string CertificateNumber,
    string Type,
    DateTime IssueDate,
    DateTime? ExpiryDate
);

public record CreateCertificateRequest(
    string CertificateNumber,
    string Type,
    DateTime IssueDate,
    DateTime? ExpiryDate,
    int? ClientId,
    int? EmployerId
);
