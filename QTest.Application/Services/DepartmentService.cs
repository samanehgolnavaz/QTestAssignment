using QTest.Application.DTOs;
using QTest.Application.Interfaces;
using QTest.Domain.Entities;
using System.Net.Http.Headers;

namespace QTest.Application.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<int> CreateAsync(CreateDepartmentDto dto, CancellationToken cancellationToken)
    {
        var department = new Department
        {
            Budget = dto.budget,
            HasPrinter = dto.hasPrinter,
            Location = dto.location,
            Name = dto.name,
        };

        await _departmentRepository.CreateAsync(department, cancellationToken);
        await _departmentRepository.SaveChangesAsync(cancellationToken);

        return department.Id;
    }

    public async Task UpdatePrinterStatusAsync(UpdateDepartmentPrinterStatusDto dto, CancellationToken cancellationToken)
    {
        var department = await _departmentRepository.GetDepartmentByIdAsybc(dto.departmentId, cancellationToken);

        if (department == null)
        {
            throw new Exception("Invalid your department Id.");
        }

        department.HasPrinter = dto.hasPrinter;
        
        await _departmentRepository.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<DepartmentItemDto>> GetDepartments(int countOfEmplyee, CancellationToken cancellationToken)
    {
        var departments = await _departmentRepository.GetAllAsync(countOfEmplyee, cancellationToken);

        return departments.Select(x => new DepartmentItemDto(x.Id,x.Name,x.HasPrinter,x.Location)).ToList();
    }
}
