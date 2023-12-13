using System.ComponentModel.DataAnnotations;

namespace QTest.API.Contracts;

public sealed record CreateEmployeeRequest(
    [MaxLength(100)] string Name, 
    decimal salary, 
    DateOnly birthOfDate,
    int departmentId);
