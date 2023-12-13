namespace QTest.API.Contracts;

public sealed record UpdateDepartmentPrinterStatusRequest(int departmentId, bool hasPrinter);
