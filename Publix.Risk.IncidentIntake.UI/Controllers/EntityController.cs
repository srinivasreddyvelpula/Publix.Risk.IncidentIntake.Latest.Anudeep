using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Publix.Risk.IncidentIntake.Domain.Features.Entity;
using System.Threading.Tasks;


namespace Publix.Risk.IncidentIntake.UI.Controllers
{

    [ApiController]
    [Route("api/entity")]
    public class EntityController : BaseAPIController
    {
        public EntityController(ILogger logger, IConfiguration config, IMediator mediator) : base(logger, config, mediator)
        {
        }


        [HttpGet]
        public async Task<SearchEntitysResult> SearchEntities(
                [FromQuery] string first,
                [FromQuery] string last,
                [FromQuery] string abbrev,
                [FromQuery] string city,
                [FromQuery] string state,
                [FromQuery] int page = 1,
                [FromQuery] int pageSize = -1) => await Mediator.Send(new SearchEntitysQuery(first, last, abbrev, city, state, page, pageSize));


        [HttpGet("{entityId}")]
        public async Task<GetEntityResult> GetEntityById(int entityId) => await Mediator.Send(new GetEntityQuery(entityId));


        [HttpPost]
        public async Task<CreateEntityResult> CreateEntity([FromBody] CreateEntityCommand command) => await Mediator.Send(command);
    }
}
