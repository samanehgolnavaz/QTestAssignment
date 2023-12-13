namespace QTest.Application.DTOs;

public sealed record CreateDepartmentDto(
    string name,
    string location,
    decimal budget,
    bool hasPrinter);
