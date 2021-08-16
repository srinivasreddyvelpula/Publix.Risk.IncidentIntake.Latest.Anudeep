using MediatR;
using Microsoft.AspNetCore.Mvc;
using Publix.Risk.IncidentIntake.Domain.Core.CQRS;
using Publix.Risk.IncidentIntake.Domain.Core.Interfaces;
using System.Threading.Tasks;


namespace Publix.Risk.IncidentIntake.API.Controllers
{

    [ApiController]
    [Route("entity")]
    public class EntityController : BaseController
    {
        public EntityController(ILogger logger, IAPILoginRepository loginRepo, IConfig config, IMediator mediator) : base(logger, loginRepo, config, mediator)
        {
        }


        [HttpGet]
        public async Task<GetEntitysResult> GetEntities(
                [FromQuery] string first,
                [FromQuery] string last,
                [FromQuery] string abbrev,
                [FromQuery] string city,
                [FromQuery] string state,
                [FromQuery] int page = 1,
                [FromQuery] int pageSize = -1) => await Mediator.Send(new GetEntitysQuery(first, last, abbrev, city, state, page, pageSize));


        [HttpGet("{entityId}")]
        public async Task<GetEntityResult> GetEntityById(int entityId) => await Mediator.Send(new GetEntityQuery(entityId));


        [HttpPost]
        public async Task<CreateEntityResult> CreateEntity([FromBody] string jsonEntity) => await Mediator.Send(new CreateEntityCommand() { JsonEntity = jsonEntity });
    }
}
