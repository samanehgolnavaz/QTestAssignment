using QTest.Application.Interfaces;
using QTest.Domain.Entities;

namespace QTest.Infrastructure.Presistence;
public class EmployeeRepository : IEmployeeRepository
{
    private readonly QTestDbContext _dbContext;
    public EmployeeRepository(QTestDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateAsync(Employee employee, CancellationToken cancellation = default)
    {
        await _dbContext.AddAsync(employee, cancellation);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}

