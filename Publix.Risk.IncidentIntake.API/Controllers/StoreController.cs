using MediatR;
using Microsoft.AspNetCore.Mvc;
using Publix.Risk.IncidentIntake.Domain.Core.CQRS;
using Publix.Risk.IncidentIntake.Domain.Core.Interfaces;
using System.Threading.Tasks;

namespace Publix.Risk.IncidentIntake.API.Controllers
{
    [ApiController]
    [Route("store")]
    public class StoreController : BaseController
    {
        private IAssureClaimsRepository claimsRepo { get; }
        private IRMXContext dbContext { get; }


        public StoreController(ILogger logger, IAssureClaimsRepository repo, IAPILoginRepository loginRepo, IRMXContext context, IConfig config, IMediator mediator) : base(logger, loginRepo, config, mediator)
        {
            claimsRepo = repo;
            dbContext = context;
        }


        [HttpGet]
        public async Task<GetStoresResult> GetStores(
                [FromQuery] string number,
                [FromQuery] string city,
                [FromQuery] string state,
                [FromQuery] int page = 1,
                [FromQuery] int pageSize = -1) => await Mediator.Send(new GetStoresQuery(number, city, state, page, pageSize));


        [HttpGet("{entityId}")]
        public async Task<GetEntityResult> GetStoreByEntityId(int entityId) => await Mediator.Send(new GetEntityQuery(entityId));
    }
}
