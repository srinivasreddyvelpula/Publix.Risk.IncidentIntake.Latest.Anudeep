using MediatR;
using Microsoft.AspNetCore.Mvc;
using Publix.Risk.IncidentIntake.Domain.Core.CQRS;
using Publix.Risk.IncidentIntake.Domain.Core.Interfaces;
using System.Threading.Tasks;


namespace Publix.Risk.IncidentIntake.API.Controllers
{
    [ApiController]
    [Route("incident")]
    public class IncidentController : BaseController
    {
        public IncidentController(ILogger logger, IAPILoginRepository loginRepo, IConfig config, IMediator mediator) : base(logger, loginRepo, config, mediator)
        {
        }


        [HttpPost]
        public async Task<CreateIncidentResult> CreateIncident([FromBody] string jsonIncident) => await Mediator.Send(new CreateIncidentCommand(jsonIncident));
    }
}
