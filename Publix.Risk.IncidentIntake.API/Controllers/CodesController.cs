using MediatR;
using Microsoft.AspNetCore.Mvc;
using Publix.Risk.IncidentIntake.Domain.Core.CQRS;
using Publix.Risk.IncidentIntake.Domain.Core.Interfaces;
using System.Threading.Tasks;


namespace Publix.Risk.IncidentIntake.API.Controllers
{
    [ApiController]
    [Route("codes")]
    public class CodesController : BaseController
    {
        private IAssureClaimsRepository _repo { get; }


        public CodesController(ILogger logger, IAssureClaimsRepository repo, IAPILoginRepository loginRepo, IConfig config, IMediator mediator) : base(logger, loginRepo, config, mediator)
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