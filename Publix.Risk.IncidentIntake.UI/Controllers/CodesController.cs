using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Publix.Risk.IncidentIntake.Domain.Features.Code;
using Publix.Risk.IncidentIntake.Domain.Interfaces;
using System.Threading.Tasks;


namespace Publix.Risk.IncidentIntake.UI.Controllers
{
    [ApiController]
    [Route("api/codes")]
    public class CodesController : BaseAPIController
    {
        private IAssureClaimsRepository _repo { get; }

        public CodesController(ILogger logger, IAssureClaimsRepository repo, IConfiguration config, IMediator mediator) : base(logger, config, mediator)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<GetCodesListResult> GetCodeTypeList()
        {
            var results = await Mediator.Send(new GetCodesListQuery());
            return results;
        }

        [HttpGet("{codeTypeId}")]
        public async Task<GetCodesResult> GetCodesByTypeId(int codeTypeId) => await Mediator.Send(new GetCodesQuery(codeTypeId));
    }
}