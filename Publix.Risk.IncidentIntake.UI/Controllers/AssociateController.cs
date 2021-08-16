using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Publix.Risk.IncidentIntake.Domain.Features.Associate;
using System.Threading.Tasks;


namespace Publix.Risk.IncidentIntake.UI.Controllers
{
    [ApiController]
    [Route("api/associate")]
    public class AssociateController : BaseAPIController
    {
        public AssociateController(ILogger logger, IConfiguration config, IMediator mediator) : base(logger, config, mediator)
        {
        }

        [HttpGet]
        public async Task<SearchAssociatesResult> GetAssociates(
                                            [FromQuery] string? first,
                                            [FromQuery] string? last,
                                            [FromQuery] string? pernr,
                                            [FromQuery] string? costCenter,
                                            [FromQuery] int page = 1,
                                            [FromQuery] int pageSize = -1) => await Mediator.Send(new SearchAssociatesQuery(pernr, first, last, costCenter, page, pageSize));


        [HttpGet("{pernr}")]
        public async Task<GetAssociateResult> GetAssociateByPERNR(string pernr) => await Mediator.Send(new GetAssociateQuery(pernr));
    }
}