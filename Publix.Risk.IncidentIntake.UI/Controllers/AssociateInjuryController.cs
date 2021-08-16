using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using Publix.Risk.IncidentIntake.Domain.Features.Code;
using Publix.Risk.IncidentIntake.Domain.Features.Entity;
using Publix.Risk.IncidentIntake.Domain.Features.Incident;
using Publix.Risk.IncidentIntake.UI.Models;
using Publix.Risk.IncidentIntake.UI.Pipelines;

using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Publix.Risk.IncidentIntake.UI.Controllers
{
    public class AssociateInjuryController : BaseController
    {
        public AssociateInjuryController(IHTTPClientHelper hTTPClientHelper)
            : base(hTTPClientHelper)
        {
        }
        public async Task<IActionResult> Index()
        {
            AssociateInjuryViewModel model = new AssociateInjuryViewModel();
            model.YesNoOnlyOptions = await this.HTTPClientHelper.GetDropdownValues(Constants.YesNoOnly_CodeTypeId);
            model.YesNoUnkownOptions = await this.HTTPClientHelper.GetDropdownValues(Constants.YesNoUnkown_CodeTypeId);
            model.ShiftsOptions = await this.HTTPClientHelper.GetDropdownValues(Constants.Shifts_CodeTypeId);
            model.ActivityEngagementsOptions = await this.HTTPClientHelper.GetDropdownValues(Constants.ActivityEngagements_CodeTypeId);
            model.InsideOutsideOptions = await this.HTTPClientHelper.GetDropdownValues(Constants.InsideOutside_CodeTypeId);
            model.ClaimTypesOptions = await this.HTTPClientHelper.GetDropdownValues(Constants.ClaimTypes_CodeTypeId);
            model.IncidentTypesOptions = await this.HTTPClientHelper.GetDropdownValues(Constants.IncidentTypes_CodeTypeId);
            model.FloorTypesOptions = await this.HTTPClientHelper.GetDropdownValues(Constants.FloorTypes_CodeTypeId);
            model.StatesOptions = await this.HTTPClientHelper.GetDropdownValues(Constants.States_CodeTypeId);
            model.LocationTypesOptions = await this.HTTPClientHelper.GetDropdownValues(Constants.LocationTypes_CodeTypeId);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> PostIncident(AssociateInjuryViewModel associateInjuryViewModel)
        {
            if (ModelState.IsValid)
            {
                var entity = MapFrom(associateInjuryViewModel);
                var json = JsonConvert.SerializeObject(entity);
                using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    var result = await this.HTTPClientHelper.PostAsync<AssociateInjuryIncident>("api/incident", stringContent);
                }
            }
            return View(associateInjuryViewModel);
        }

        private AssociateInjuryIncident MapFrom(AssociateInjuryViewModel associateInjuryViewModel)
        {
            var associateInjuryIncident = new AssociateInjuryIncident()
            {
                ActivityEngagedId = associateInjuryViewModel.ActivityEngaged,
                BloodOPIM = associateInjuryViewModel.BloodOPIM,
                Chemicals = new int[] { associateInjuryViewModel.ChemicalsType },
                ClaimJuris = associateInjuryViewModel.ClaimType,
                ChemicalsInvolved = associateInjuryViewModel.Chemicals,
                ClaimTypeId = associateInjuryViewModel.ClaimType,
                DateTimeClaimClosed = associateInjuryViewModel.DateReported.ToString(),
                EmpActions = associateInjuryViewModel.EmpActions,
                EmpDescription = associateInjuryViewModel.EmpDesc,
                DetailedLocation = associateInjuryViewModel.DetailedLocation,
                EmpDrugTested = associateInjuryViewModel.EmpDrugTested,
                EmpFell = associateInjuryViewModel.EmpFall,
                EquipmentInvolved = associateInjuryViewModel.EquipmentInvolved,
                FloorTypeId = associateInjuryViewModel.FloorType,
                HospitalOvernight = associateInjuryViewModel.HospitalOvernight,
                IncidentAtPublix = associateInjuryViewModel.IncidentAtPublix == 5160 ? true : false,
                MedicalCareSought = associateInjuryViewModel.MedicalCareSought == 5160 ? true : false,
                MedicalLocation = new Location(),
                MedicalProfessional = associateInjuryViewModel.MedicalProfessional,
                EmpWitnesses = new InvolvedAssociate[] { },
                NonEmpInvloved = new EntityEntity[] { },
                OSHARecordable = associateInjuryViewModel.OSHARecordable,
                PPERelated = associateInjuryViewModel.PPERelated,
                PPEWorn = associateInjuryViewModel.PPEWorn,
                ShiftId = associateInjuryViewModel.Shift,
                VendorInvolved = associateInjuryViewModel.VendorInvolved,
                Vendor = new EntityEntity() { },
                TreatedInER = associateInjuryViewModel.TreatedInER,
                ReporterPERNR = associateInjuryViewModel.MgrPernr,
                TransportedEMS = associateInjuryViewModel.TransportedEMS

            };
            return associateInjuryIncident;
        }
    }
}
