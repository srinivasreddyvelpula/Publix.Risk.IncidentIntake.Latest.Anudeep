using Microsoft.AspNetCore.Mvc.Rendering;
using Publix.Risk.IncidentIntake.Domain.Features.Incident;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Publix.Risk.IncidentIntake.UI.Models
{
    public class CartDamageViewModel
    {
        [Required]
        public string PrimaryCustomerName { get; set; }
        [Required]
        public int? EmpPernr { get; set; }
        [Required]
        public int? MgrPernr { get; set; }
        [Required]
        public DateTime DateReported { get; set; }
        [Required]
        public string TimeReported { get; set; }

        [Required]
        public DateTime DateIncident { get; set; }
        [Required]
        public string TimeIncident { get; set; }
        [Required]
        public string CostCenter { get; set; }
        [Required]
        [MaxLength(500)]
        public string CustomerDescription { get; set; }
        [Required]
        [MaxLength(500)]
        public string ManagerDescription { get; set; }


        public List<SelectListItem> WeatherCondition { get; set; }

        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public int? WeatherConditionId { get; set; }
        public int? Reason { get; set; }
        public string ReasonExplanation { get; set; }

        public int? PhotoGrpahsTaken { get; set; }
        public int? IncidentCoveredByVideo { get; set; }
        public string Camera { get; set; }
        public string EmployeeWitness { get; set; }
        public string NonEmployeeWitness { get; set; }
        public int? AssociateAdminFault { get; set; }
        public int? DamageMatchesUp { get; set; }

        public int? ParkingCart { get; set; }
        public string ExtentofDamage { get; set; }
        public string DamageMatchExplain { get; set; }
        public List<SelectListItem> CartDamageCause { get; set; }
        [Required]
        public int CartDamageCauseId { get; set; }
        [Required]
        public int? OtherCustomerId { get; set; }
        public string Other { get; set; }


        public List<SelectListItem> State { get; set; }

        public int? SelectedState { get; set; }
        public List<SelectListItem> PrimaryLanguage { get; set; }
        public int? PrimaryLanguageId { get; set; }
        public List<SelectListItem> Gender { get; set; }
        public int? GenderId { get; set; }

        public int? MinorId { get; set; }
        public List<SelectListItem> YesNoList { get; set; }
        public int? OwnerId { get; set; }

        public CartDamageIncident CartDamageModel { get; set; }
    }
}
