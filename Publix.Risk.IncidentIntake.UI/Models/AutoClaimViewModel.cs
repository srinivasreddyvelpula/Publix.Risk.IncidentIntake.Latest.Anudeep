using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Publix.Risk.IncidentIntake.UI.Models
{
    public class AutoClaimViewModel
    {
        public string VehiclesInvolved { get; set; }
        public string AssociateOccupants { get; set; }
        public string NonAssociateOccupants { get; set; }
        [Required]
        public int? EmpPernr { get; set; }
        public string Name { get; set; }

        public DateTime? DateReported { get; set; }
        public string TimeReported { get; set; }
        public DateTime? DateofIncident { get; set; }
        public string TimeofIncident { get; set; }
        public IEnumerable<SelectListItem> WeatherCondition { get; set; }
        public int? WeatherConditionId { get; set; }
        public int?  TimeofDayId { get; set; }
        public IEnumerable<SelectListItem> TimeofDay { get; set; }
        public int? FireorExplosion { get; set; }
        public int? NonVehiclePropertyDamage { get; set; }
        public int? LossCategoryId { get; set; }
        public IEnumerable<SelectListItem> LossCategory { get; set; }
        public int? AccidentTypeId { get; set; }

        public IEnumerable<SelectListItem> YesNoList { get; set; }
        public IEnumerable<SelectListItem> YesNoUnknownList { get; set; }
        public IEnumerable<SelectListItem> AccidentType { get; set; }

        public string AccidentDescription { get; set; }

        public string TPALocationcode { get; set; }
        public IEnumerable<SelectListItem> IncidentLocation { get; set; }
        public int? LocationId { get; set; }
        public string AssociateWitness { get; set; }
        public string NonAssociateWitness  { get; set; }
    }
}
