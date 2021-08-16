using MediatR;
using Microsoft.AspNetCore.Mvc;
using Publix.Risk.IncidentIntake.Domain.Core.Interfaces;
using System;

namespace Publix.Risk.IncidentIntake.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private const string TOKEN_HEADER_NAME = "X-PUBLIX-II-API-TOKEN";


        protected IAPILoginRepository _LoginRepo { get; }
        protected ILogger _logger { get; }
        protected IConfig _config { get; }
        protected IMediator Mediator { get; }


        public BaseController(ILogger logger, IAPILoginRepository repo, IConfig config, IMediator mediator)
        {
            _logger = logger;
            _LoginRepo = repo;
            _config = config;
            Mediator = mediator;
        }


        protected string ValidateRequest()
        {
#if DEBUG
            return Guid.Empty.ToString();
#endif
            string token = Request.Headers[TOKEN_HEADER_NAME];

            if (_LoginRepo.ValidateToken(token))
            {
                return token;
            }

            return null;
        }
    }
}
