using Microsoft.AspNetCore.Mvc;
using QTest.API.Contracts;
using QTest.Application.DTOs;
using QTest.Application.Interfaces;

namespace QTest.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet(Name = "Create")]
        public async Task<IActionResult> Create(CreateEmployeeRequest request, CancellationToken cancellationToken)
        {

            var dto = new CreateEmployeeDto(request.Name,request.salary,request.birthOfDate,request.departmentId);

            try
            {
                var result = await _employeeService.CreateAsync(dto, cancellationToken);
                return Ok(request);
            }
            catch (Exception)
            {
                return BadRequest("Invalid operation");
            }
        }
    }
}
