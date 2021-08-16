using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Publix.Risk.IncidentIntake.UI.Models
{
    public class PropertyDamageViewModel
    {
        public int? AssociateEmpPernr { get; set; }
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
        public string IncidentAtLocation { get; set; }
        [Required]
        [MaxLength(500)]
        public string CustomerDescription { get; set; }
        [Required]
        [MaxLength(500)]
        public string ManagerDescription { get; set; }
 
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        
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

        public string PropertyDamage { get; set; }
        public string AllegedCause { get; set; }
        public string ApproxValue { get; set; }
        public string AssociateInvolved  { get; set; }
        public string VendorInvolved { get; set; }
        public List<SelectListItem> State { get; set; }

        public int? SelectedState { get; set; }
        public List<SelectListItem> PrimaryLanguage { get; set; }
        public int? PrimaryLanguageId { get; set; }
        public List<SelectListItem> Gender { get; set; }
        public int? GenderId { get; set; }
        
        public int? MinorId { get; set; }
        public List<SelectListItem> YesNoList { get; set; }
        public List<SelectListItem> YesNoUnknownList { get; set; }
        //public CartDamagePersonInvolvedModel CartDamageModel { get; set; }
        public string CostCenter { get; set; }
        public string LocationName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string state { get; set; }
        public string Zip { get; set; }
    }
}
