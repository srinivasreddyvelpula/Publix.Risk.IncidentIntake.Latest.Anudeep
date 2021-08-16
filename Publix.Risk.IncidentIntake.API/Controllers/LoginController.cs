using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Publix.Risk.IncidentIntake.Domain.Core.Interfaces;
using System;
using System.Text;
using System.Threading.Tasks;


namespace Publix.Risk.IncidentIntake.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : BaseController
    {
        public LoginController(ILogger logger, IAPILoginRepository repo, IConfig config, IMediator mediator) : base(logger, repo, config, mediator)
        {
        }


        [HttpGet]
        public ActionResult<string> Login([FromQuery(Name = "username")] string username, [FromHeader(Name = "X-RISK-II-PWD")] string password)
        {
            try
            {
                byte[] bytes = Base64UrlTextEncoder.Decode(password);
                string pwd = ASCIIEncoding.UTF8.GetString(bytes);

                if (_LoginRepo.IsValidLogin(username, pwd))
                {
                    string token = _LoginRepo.GetToken(username, DateTime.Now);

                    if (!string.IsNullOrEmpty(token))
                    {
                        return new ActionResult<string>(token);
                    }
                    else
                    {
                        return new BadRequestResult();
                    }
                }

                return new UnauthorizedResult();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, null);
                return new BadRequestResult();
            }
        }


        [HttpPut]
        public async Task<ActionResult<bool>> Logout()
        {
            string token = ValidateRequest();

            if (!string.IsNullOrEmpty(token))
            {
                return new ActionResult<bool>(_LoginRepo.Logout(token));
            }

            return new UnauthorizedResult();
        }
    }
}
