using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Publix.Risk.IncidentIntake.Domain.Features.Associate;
using Publix.Risk.IncidentIntake.UI.Models;
using Publix.Risk.IncidentIntake.UI.Pipelines;
using System.Threading.Tasks;

namespace Publix.Risk.IncidentIntake.UI.Controllers
{
    public class AutoClaimController : Controller
    {
        private ILogger _logger;
        private IHTTPClientHelper _httpClientHelper;

        public AutoClaimController(ILogger logger, IHTTPClientHelper httpClientHelper)
        {
            _logger = logger;
            _httpClientHelper = httpClientHelper;

        }
        private async Task AssignDropDownValues(AutoClaimViewModel model)
        {

            model.WeatherCondition = await _httpClientHelper.GetDropdownValues(Constants.Weather_CodeTypeId);
            model.IncidentLocation = await _httpClientHelper.GetDropdownValues(Constants.IncidentLocation_CodeTypeId);
            model.TimeofDay = await _httpClientHelper.GetDropdownValues(Constants.TimeofDay_CodeTypeId);
           // model.LossCategory = await _httpClientHelper.GetDropdownValues(Constants.Lossc);
            model.AccidentType = await _httpClientHelper.GetDropdownValues(Constants.AccidentType_CodeTypeId);
            model.YesNoList = await _httpClientHelper.GetDropdownValues(Constants.YesNoOnly_CodeTypeId);
            model.YesNoUnknownList = await _httpClientHelper.GetDropdownValues(Constants.YesNoUnkown_CodeTypeId);
            
        }
        [HttpGet]
        public async Task<SearchAssociatesResult> SearchLocationsResultAsync([FromQuery] string? first,
                                            [FromQuery] string? last,
                                            [FromQuery] string? pernr,
                                            [FromQuery] string? costCenter,
                                            [FromQuery] int page = 1,
                                            [FromQuery] int pageSize = -1)
        {
            var result = await _httpClientHelper.GetAsync<SearchAssociatesResult>("api/associate");
            return result;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var model = new AutoClaimViewModel();
            await AssignDropDownValues(model);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(AutoClaimViewModel autoClaimViewmodel)
        {
            if (ModelState.IsValid)
            {

            }
            else
            {
                await AssignDropDownValues(autoClaimViewmodel);
                return View(autoClaimViewmodel);
            }
            return null;
        }

    }
}
