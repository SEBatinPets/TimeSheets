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
    public class UsersController : ControllerBase
    {
        private readonly IUsersManager userManager;
        public UsersController(IUsersManager userManager)
        {
            this.userManager = userManager;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var cts = new CancellationTokenSource();
            var result = await userManager.GetByIdAsync(id, cts.Token);
            return Ok(JsonSerializer.Serialize(result));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var cts = new CancellationTokenSource();
            await userManager.DeleteByIdAsync(id, cts.Token);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserDto userDto)
        {
            var cts = new CancellationTokenSource();
            await userManager.CreateAsync(userDto, cts.Token);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserDto userDto)
        {
            var cts = new CancellationTokenSource();
            await userManager.UpdateAsync(userDto, cts.Token);
            return Ok();
        }
    }
}
