namespace ISCC.Application.DTOs;

public record InspectionDto(
    int Id,
    string InspectionNumber,
    DateTime InspectionDate,
    string Status,
    string? Notes
);

public record CreateInspectionRequest(
    string InspectionNumber,
    DateTime InspectionDate,
    string? Notes,
    int? ClientId,
    int? EmployerId
);
