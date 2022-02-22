using DomainLibrary.Domain.Managers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLibrary.Models.DTO;
using System.Threading;
using System.Threading.Tasks;

namespace TimeSheets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonManager personManager;
        public PersonsController(IPersonManager personManager)
        {
            this.personManager = personManager;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken token)
        {
            var result = await personManager.GetByIdAsync(id, token);

            return Ok(result);
        }
        [HttpGet("search/{name}")]
        public async Task<IActionResult> GetByName([FromRoute] string name, CancellationToken token)
        {
            var result = await personManager.GetByNameAsync(name, token);

            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetByPagination(
            [FromQuery] int skip, 
            [FromQuery] int take, 
            CancellationToken token)
        {
            var result = await personManager.GetByPaginationAsync(skip, take, token);

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PersonDto personDto, CancellationToken token)
        {
            await personManager.CreateAsync(personDto, token);

            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PersonDto personDto, CancellationToken token)
        {
            var resultCode = await personManager.UpdateAsync(personDto, token);

            return StatusCode(resultCode);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
        {
            await personManager.DeleteByIdAsync(id, token);

            return Ok();
        }

    }
}
