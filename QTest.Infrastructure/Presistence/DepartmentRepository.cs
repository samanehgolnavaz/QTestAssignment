using Microsoft.EntityFrameworkCore;
using QTest.Application.Interfaces;
using QTest.Domain.Entities;

namespace QTest.Infrastructure.Presistence;
public class DepartmentRepository : IDepartmentRepository
{
    private readonly QTestDbContext _dbContext;
    public DepartmentRepository(QTestDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateAsync(Department department, CancellationToken cancellation = default)
    {
        await _dbContext.AddAsync(department, cancellation);
    }

    public async Task<IList<Department>> GetAllAsync(int countOfEmployees, CancellationToken cancellation)
    {
        return await _dbContext.Departments.Where(x => x.Employees.Count() >= countOfEmployees).ToListAsync(cancellation);
    }

    public async Task<Department?> GetDepartmentByIdAsybc(int Id, CancellationToken cancellation = default)
    {
        return await _dbContext.FindAsync<Department>(Id, cancellation);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}

