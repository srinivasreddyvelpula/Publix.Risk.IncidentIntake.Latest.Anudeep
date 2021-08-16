using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Publix.Risk.IncidentIntake.Domain.Features.Associate;
using Publix.Risk.IncidentIntake.UI.Models;
using Publix.Risk.IncidentIntake.UI.Pipelines;
using System.Threading.Tasks;

namespace Publix.Risk.IncidentIntake.UI.Controllers
{
    public class PropertyDamageController : Controller
    {
        private ILogger _logger;
        private IHTTPClientHelper _httpClientHelper;

        public PropertyDamageController(ILogger logger, IHTTPClientHelper httpClientHelper)
        {
            _logger = logger;
            _httpClientHelper = httpClientHelper;

        }
        private async Task AssignDropDownValues(PropertyDamageViewModel model)
        {


            model.CartDamageCause = await _httpClientHelper.GetDropdownValues(Constants.CartDamageCause_codeTypeId);
            model.State = await _httpClientHelper.GetDropdownValues(Constants.States_CodeTypeId);
            model.PrimaryLanguage = await _httpClientHelper.GetDropdownValues(Constants.PrimaryLanguage_CodeTypeId);
            model.Gender = await _httpClientHelper.GetDropdownValues(Constants.Gender_CodeTypeId);
            model.YesNoList = await _httpClientHelper.GetDropdownValues(Constants.YesNoOnly_CodeTypeId);
            model.YesNoUnknownList = await _httpClientHelper.GetDropdownValues(Constants.YesNoUnkown_CodeTypeId);
            //model.CartDamageModel = new CartDamagePersonInvolvedModel()
            //{
            //    Country = await _httpClientHelper.GetDropdownValues(Constants.Country_CodeTypeId),
            //    State= model.State,
            //    PrimaryLanguage = model.PrimaryLanguage,
            //    Minor = model.YesNoList,
            //    Gender = model.Gender
            //};

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

            var model = new PropertyDamageViewModel();
            await AssignDropDownValues(model);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(PropertyDamageViewModel cartDamageViewModel)
        {
            if (ModelState.IsValid)
            {

            }
            else
            {
                await AssignDropDownValues(cartDamageViewModel);
                return View(cartDamageViewModel);
            }
            return null;
        }

    }
}
