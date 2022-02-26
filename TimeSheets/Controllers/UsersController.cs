using DomainLibrary.Domain.Managers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLibrary.Models.DTO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace TimeSheets.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> Get([FromRoute] int id, CancellationToken token)
        {
            var result = await userManager.GetByIdAsync(id, token);
            return Ok(JsonSerializer.Serialize(result));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
        {
            var result = await userManager.DeleteByIdAsync(id, token);
            return StatusCode(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserDto userDto, CancellationToken token)
        {
            var result = await userManager.CreateAsync(userDto, token);
            return StatusCode(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserDto userDto, CancellationToken token)
        {
            var result = await userManager.UpdateAsync(userDto, token);
            return StatusCode(result);
        }
    }
}
