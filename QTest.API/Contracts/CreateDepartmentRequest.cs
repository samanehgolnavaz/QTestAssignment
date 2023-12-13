using System.ComponentModel.DataAnnotations;

namespace QTest.API.Contracts;

public sealed record CreateDepartmentRequest(
    [MaxLength(10)] string name,
    string location,
    decimal budget,
    bool hasPrinter);
