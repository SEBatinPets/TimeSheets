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
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var cts = new CancellationTokenSource();
            var result = await personManager.GetByIdAsync(id, cts.Token);

            return Ok(result);
        }
        [HttpGet("search/{name}")]
        public async Task<IActionResult> GetByName([FromRoute] string name)
        {
            var cts = new CancellationTokenSource();
            var result = await personManager.GetByNameAsync(name, cts.Token);

            return Ok(result);
        }
        [HttpGet("skip/{skip}/take/{take}")]
        public async Task<IActionResult> GetByPagination([FromRoute] int skip, [FromRoute] int take)
        {
            var cts = new CancellationTokenSource();
            var result = await personManager.GetByPaginationAsync(skip, take, cts.Token);

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PersonDto personDto)
        {
            var cts = new CancellationTokenSource();
            await personManager.CreateAsync(personDto, cts.Token);

            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PersonDto personDto)
        {
            var cts = new CancellationTokenSource();
            await personManager.UpdateAsync(personDto, cts.Token);

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var cts = new CancellationTokenSource();
            await personManager.DeleteByIdAsync(id, cts.Token);

            return Ok();
        }

    }
}
