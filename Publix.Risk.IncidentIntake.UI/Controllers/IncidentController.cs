using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Publix.Risk.IncidentIntake.Domain.Features.Incident;
using System.Threading.Tasks;


namespace Publix.Risk.IncidentIntake.UI.Controllers
{
    [ApiController]
    [Route("api/incident")]
    public class IncidentController : BaseAPIController
    {
        public IncidentController(ILogger logger, IConfiguration config, IMediator mediator) : base(logger, config, mediator)
        {
        }


        [HttpPost]
        public async Task<CreateIncidentResult> CreateIncident([FromBody] CreateIncidentCommand incident) => await Mediator.Send(incident);
    }
}
