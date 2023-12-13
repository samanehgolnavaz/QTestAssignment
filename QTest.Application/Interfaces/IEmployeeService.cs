using QTest.Application.DTOs;
using QTest.Domain.Entities;

namespace QTest.Application.Interfaces;

public interface IEmployeeService
{
    Task<int> CreateAsync(CreateEmployeeDto dto, CancellationToken cancellationToken);


}
