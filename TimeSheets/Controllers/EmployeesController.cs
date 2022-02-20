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
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var cts = new CancellationTokenSource();
            var result = await employeesManager.GetByIdAsync(id, cts.Token);
            return Ok(JsonSerializer.Serialize(result));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var cts = new CancellationTokenSource();
            await employeesManager.DeleteByIdAsync(id, cts.Token);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeDto employeeDto)
        {
            var cts = new CancellationTokenSource();
            await employeesManager.CreateAsync(employeeDto, cts.Token);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EmployeeDto employeeDto)
        {
            var cts = new CancellationTokenSource();
            await employeesManager.UpdateAsync(employeeDto, cts.Token);
            return Ok();
        }
    }
}
