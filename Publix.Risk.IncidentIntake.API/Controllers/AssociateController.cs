using MediatR;
using Microsoft.AspNetCore.Mvc;
using Publix.Risk.IncidentIntake.Domain.Core.CQRS;
using Publix.Risk.IncidentIntake.Domain.Core.Interfaces;
using System.Threading.Tasks;


namespace Publix.Risk.IncidentIntake.API.Controllers
{
    [ApiController]
    [Route("associate")]
    public class AssociateController : BaseController
    {
        public AssociateController(ILogger logger, IAPILoginRepository loginRepo, IConfig config, IMediator mediator) : base(logger, loginRepo, config, mediator)
        {
        }


        [HttpGet]
        public async Task<GetAssociatesResult> GetAssociates(
                                            [FromQuery] string? first,
                                            [FromQuery] string? last,
                                            [FromQuery] string? pernr,
                                            [FromQuery] string? costCenter,
                                            [FromQuery] int page = 1,
                                            [FromQuery] int pageSize = -1) => await Mediator.Send(new GetAssociatesQuery(pernr, first, last, costCenter, page, pageSize));


        [HttpGet("{pernr}")]
        public async Task<LoadAssociateResult> GetAssociateByPERNR(string pernr) => await Mediator.Send(new LoadAssociateQuery(pernr));
    }
}