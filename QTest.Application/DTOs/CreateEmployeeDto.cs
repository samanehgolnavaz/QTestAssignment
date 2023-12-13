namespace QTest.Application.DTOs;

public sealed record CreateEmployeeDto(
    string Name, 
    decimal salary, 
    DateOnly birthOfDate,
    int departmentId);
