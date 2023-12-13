namespace QTest.Application.DTOs;

public sealed record CreateEmployeeDto(
    string Name, 
    decimal salary, 
    DateTime birthOfDate,
    int departmentId);
