using QTest.Application.DTOs;

namespace QTest.Application.Interfaces;

public interface IDepartmentService
{
    Task<int> CreateAsync(CreateDepartmentDto dto, CancellationToken cancellationToken);

    Task UpdatePrinterStatusAsync(UpdateDepartmentPrinterStatusDto dto, CancellationToken cancellationToken);

    Task<IList<DepartmentItemDto>> GetDepartments(int countOfEmplyee, CancellationToken cancellationToken);

}
