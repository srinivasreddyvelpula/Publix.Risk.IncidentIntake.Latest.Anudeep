using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Publix.Risk.IncidentIntake.UI.Models
{
    public class AssociateInjuryViewModel
    {
        [Required]
        public string EmpInjPERNR { get; set; }
        [Required]
        public string EmpInjName { get; set; }
        [Required]
        public string EmpPernr { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string MgrPernr { get; set; }
        [Required]
        public string MgrName { get; set; }
        [Required]
        public DateTime DateReported { get; set; }
        [Required]
        public DateTime TimeReported { get; set; }
        [Required]
        public int IncidentAtPublix { get; set; }
        [Required]
        public int LocationType { get; set; }
        [Required]
        public int CostCenter { get; set; }
        [Required]
        public string LocationName { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        [Required]
        public DateTime IncidentDate { get; set; }
        [Required]
        public DateTime IncidentTime { get; set; }
        public int Shift { get; set; }
        [Required]
        public string EmpDesc { get; set; }
        public bool MgrAgrees { get; set; }
        public string EmpActions { get; set; }
        [Required]
        public int ActivityEngaged { get; set; }
        [Required]
        public string ExplainOther { get; set; }
        [Required]
        public bool EmpFall { get; set; }
        [Required]
        public bool VendorInvolved { get; set; }
        [Required]
        public string Vendor { get; set; }
        [Required]
        public int InsideOutside { get; set; }
        [Required]
        public int RespDept { get; set; }
        [Required]
        public int DetailedLocation { get; set; }
        [Required]
        public string LocationDesc { get; set; }
        [Required]
        public string LocationOther { get; set; }
        [Required]
        public int ClaimType { get; set; }
        [Required]
        public int IncidentType { get; set; }
        [Required]
        public string IncidentOther { get; set; }
        [Required]
        public int FloorType { get; set; }
        [Required]
        public string FloorOther { get; set; }
        [Required]
        public bool PPERelated { get; set; }
        [Required]
        public bool PPEWorn { get; set; }
        [Required]
        public bool EquipmentInvolved { get; set; }
        public string Equipment { get; set; }
        public bool Chemicals { get; set; }
        public int ChemicalsType { get; set; }
        [Required]
        public int MedicalCareSought { get; set; }
        public string MedicalProfessional { get; set; }
        public string MedicalLocation { get; set; }
        public string MedicalAddr1 { get; set; }
        public string MedicalAddr2 { get; set; }
        public string MedicalCity { get; set; }
        public string MedicalState { get; set; }
        public string MedicalZip { get; set; }
        public string MedicalPhone { get; set; }
        public bool TransportedEMS { get; set; }
        public bool TreatedInER { get; set; }
        [Required]
        public bool HospitalOvernight { get; set; }
        public bool OSHARecordable { get; set; }
        [Required]
        public bool EmpDrugTested { get; set; }
        [Required]
        public bool BloodOPIM { get; set; }
        public string OtherEmpInvolved { get; set; }
        public string NonEmpInvolved { get; set; }
        public string EmpWitnesses { get; set; }
        public string NonEmpWitnesses { get; set; }
        public bool CoveredVideo { get; set; }
        public string Camera { get; set; }
        public bool PhotsTaken { get; set; }

        public List<SelectListItem> YesNoOnlyOptions { get; set; }
        public List<SelectListItem> YesNoUnkownOptions { get; set; }
        public List<SelectListItem> ShiftsOptions { get; set; }
        public List<SelectListItem> ActivityEngagementsOptions { get; set; }
        public List<SelectListItem> InsideOutsideOptions { get; set; }
        public List<SelectListItem> ClaimTypesOptions { get; set; }
        public List<SelectListItem> IncidentTypesOptions { get; set; }
        public List<SelectListItem> FloorTypesOptions { get; set; }
        public List<SelectListItem> StatesOptions { get; set; }
        public List<SelectListItem> LocationTypesOptions { get; set; }

    }
}
