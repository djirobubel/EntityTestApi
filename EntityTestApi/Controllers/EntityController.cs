using EntityTestApi.Commands.CreateEntity;
using EntityTestApi.Models;
using EntityTestApi.Queries.GetEntity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EntityTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EntityController : Controller
    {
        private readonly IMediator _mediator;

        public EntityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{entityId}")]
        [ProducesResponseType(200, Type = typeof(Entity))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetEntity(Guid entityId)
        {
            var query = new GetEntityQuery(entityId);
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound("Entity not found.");

        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> CreateEntity([FromBody] CreateEntityCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
