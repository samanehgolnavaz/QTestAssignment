using QTest.Application.DTOs;
using QTest.Application.Interfaces;
using QTest.Domain.Entities;

namespace QTest.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IDepartmentRepository _departmentRepository;

    public EmployeeService(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
    {
        _employeeRepository = employeeRepository;
        _departmentRepository = departmentRepository;
    }

    public async Task<int> CreateAsync(CreateEmployeeDto dto, CancellationToken cancellationToken)

    {
        var department = await _departmentRepository.GetDepartmentByIdAsybc(dto.departmentId, cancellationToken);

        if (department == null)
        {
            throw new Exception("Invalid your department Id");
        }

        var employee = new Employee
        {
            BirthOfDate = dto.birthOfDate,
            DepartmentId = department.Id,
            Name = dto.Name,
            Salary = dto.salary
        };

        await _employeeRepository.CreateAsync(employee, cancellationToken);

        await _employeeRepository.SaveChangesAsync(cancellationToken);

        return employee.Id;
    }
}
