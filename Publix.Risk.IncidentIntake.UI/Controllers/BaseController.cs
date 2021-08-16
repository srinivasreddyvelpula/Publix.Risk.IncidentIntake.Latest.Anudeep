using Microsoft.AspNetCore.Mvc;

using Publix.Risk.IncidentIntake.Domain.Features.Associate;
using Publix.Risk.IncidentIntake.Domain.Features.Entity;
using Publix.Risk.IncidentIntake.UI.Models;
using Publix.Risk.IncidentIntake.UI.Pipelines;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Publix.Risk.IncidentIntake.UI.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IHTTPClientHelper HTTPClientHelper;

        public BaseController(IHTTPClientHelper hTTPClientHelper)
        {
            HTTPClientHelper = hTTPClientHelper;
        }

        [HttpPost]
        public async Task<JsonResult> LocationSearch(string number, string city, string state)
        {
            Dictionary<string, string> paramvalues = new Dictionary<string, string>();
            paramvalues.Add("number", number ?? "");
            paramvalues.Add("city", city);
            paramvalues.Add("state", state);
            var response = await this.HTTPClientHelper.GetAsync<SearchLocationsResult>("api/location/GetLocations", paramvalues);
            return Json(response.Results);
        }

        [HttpPost]
        public async Task<JsonResult> AssociateSearch(string PERNER, string firstName, string LastName, string costCenter)
        {
            Dictionary<string, string> paramvalues = new Dictionary<string, string>();
            paramvalues.Add("number", PERNER);
            paramvalues.Add("city", firstName);
            paramvalues.Add("state", LastName);
            paramvalues.Add("state", costCenter);
            var response = await this.HTTPClientHelper.GetAsync<SearchAssociatesResult>("api/associate", paramvalues);
            return Json(response.Results);
        }
    }
}
