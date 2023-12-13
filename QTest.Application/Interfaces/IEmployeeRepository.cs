using QTest.Domain.Entities;

namespace QTest.Application.Interfaces;

public interface IEmployeeRepository
{
    Task CreateAsync(Employee employee, CancellationToken cancellation = default);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
