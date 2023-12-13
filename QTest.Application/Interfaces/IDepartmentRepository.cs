using QTest.Domain.Entities;

namespace QTest.Application.Interfaces;

public interface IDepartmentRepository
{

    Task<Department?> GetDepartmentByIdAsybc(int Id, CancellationToken cancellation = default);
    
    Task CreateAsync(Department department, CancellationToken cancellation = default);

    Task<IList<Department>> GetAllAsync(int countOfEmployees, CancellationToken cancellation);

    Task SaveChangesAsync(CancellationToken cancellationToken);
}
