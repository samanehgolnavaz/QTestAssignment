using Microsoft.AspNetCore.Mvc;
using QTest.API.Contracts;
using QTest.Application.DTOs;
using QTest.Application.Interfaces;

namespace QTest.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet(Name = "Create")]
        public async Task<IActionResult> Create(CreateDepartmentRequest request, CancellationToken cancellationToken)
        {

            var dto = new CreateDepartmentDto(request.name, request.location, request.budget, request.hasPrinter);

            try
            {
                var result = await _departmentService.CreateAsync(dto, cancellationToken);
                return Ok(request);
            }
            catch (Exception)
            {
                return BadRequest("Invalid operation");
            }
        }

        [HttpGet(Name = "UpdatePrinterStatus")]
        public async Task<IActionResult> UpdatePrinter(UpdateDepartmentPrinterStatusRequest request, CancellationToken cancellationToken)
        {

            var dto = new UpdateDepartmentPrinterStatusDto(request.departmentId, request.hasPrinter);

            try
            {
                await _departmentService.UpdatePrinterStatusAsync(dto, cancellationToken);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Invalid operation");
            }
        }

        [HttpGet(Name = "UpdatePrinterStatus")]
        public async Task<IActionResult> UpdatePrinter(int CountOfEmployee, CancellationToken cancellationToken)
        {

            var result = await _departmentService.GetDepartments(CountOfEmployee, cancellationToken);

            if (result.Count == 0)
            {
                return NotFound();
            }

            return Ok(result);

        }
    }
}
