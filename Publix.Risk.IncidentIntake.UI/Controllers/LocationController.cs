using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Publix.Risk.IncidentIntake.Domain.Features.Entity;
using System.Threading.Tasks;

namespace Publix.Risk.IncidentIntake.UI.Controllers
{
    [ApiController]
    [Route("api/location")]
    public class LocationController : BaseAPIController
    {
        public LocationController(ILogger logger, IConfiguration config, IMediator mediator) : base(logger, config, mediator)
        {
        }

        [HttpGet]
        public async Task<SearchLocationsResult> GetLocations(
                [FromQuery] string desc,
                [FromQuery] string city,
                [FromQuery] string state,
                [FromQuery] int page = 1,
                [FromQuery] int pageSize = -1) => await Mediator.Send(new SearchLocationsQuery(desc, city, state, page, pageSize));

        [HttpGet("{entityId}")]
        public async Task<GetLocationResult> GetLocationByEntityId(int entityId) => await Mediator.Send(new GetLocationQuery(entityId));
    }
}
