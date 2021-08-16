using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace Publix.Risk.IncidentIntake.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseAPIController : ControllerBase
    {
        private const string TOKEN_HEADER_NAME = "X-PUBLIX-II-API-TOKEN";


        protected ILogger _logger { get; }
        protected IConfiguration _config { get; }
        protected IMediator Mediator { get; }


        public BaseAPIController(ILogger logger, IConfiguration config, IMediator mediator)
        {
            _logger = logger;
            _config = config;
            Mediator = mediator;
        }


        protected string ValidateRequest()
        {
#if DEBUG
            return Guid.Empty.ToString();
#endif
            string token = Request.Headers[TOKEN_HEADER_NAME];

            return null;
        }
    }
}
