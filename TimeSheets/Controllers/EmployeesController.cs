using DomainLibrary.Domain.Managers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLibrary.Models.DTO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace TimeSheets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public readonly IEmployeesManager employeesManager;
        public EmployeesController(IEmployeesManager employeesManager)
        {
            this.employeesManager = employeesManager;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id, CancellationToken token)
        {
            var result = await employeesManager.GetByIdAsync(id, token);
            return Ok(JsonSerializer.Serialize(result));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
        {
            var result = await employeesManager.DeleteByIdAsync(id, token);
            return StatusCode(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeDto employeeDto, CancellationToken token)
        {
            var result = await employeesManager.CreateAsync(employeeDto, token);
            return StatusCode(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EmployeeDto employeeDto, CancellationToken token)
        {
            var result = await employeesManager.UpdateAsync(employeeDto, token);
            return StatusCode(result);
        }
    }
}
