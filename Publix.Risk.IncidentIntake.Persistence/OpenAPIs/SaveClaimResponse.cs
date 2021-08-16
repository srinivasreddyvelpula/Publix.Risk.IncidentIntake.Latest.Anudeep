namespace Publix.Risk.IncidentIntake.Persistence.AssureClaims
{
    public class SaveClaimResponse
    {
        public object primaryPiEmployee { get; set; }
        public Proprowid propRowId { get; set; }
        public int claimId { get; set; }
        public int eventId { get; set; }
        public string eventNumber { get; set; }
        public string claimNumber { get; set; }
        public Claimstatuscode claimStatusCode { get; set; }
        public Lineofbuscode lineOfBusCode { get; set; }
        public bool openFlag { get; set; }
        public Claimtypecode claimTypeCode { get; set; }
        public string dttmClosed { get; set; }
        public string dateOfClaim { get; set; }
        public string timeOfClaim { get; set; }
        public string fileNumber { get; set; }
        public Methodclosedcode methodClosedCode { get; set; }
        public bool paymntFrozenFlag { get; set; }
        public bool leaveOnlyFlag { get; set; }
        public bool lssClaimInd { get; set; }
        public bool vssClaimInd { get; set; }
        public string emailAddresses { get; set; }
        public string mailSent { get; set; }
        public string submitToISOFlag { get; set; }
        public Currencytype currencyType { get; set; }
        public Policylobcode policyLOBCode { get; set; }
        public Primarypolicyid primaryPolicyId { get; set; }
        public Primarypolicyidenh primaryPolicyIdEnh { get; set; }
        public Servicecode serviceCode { get; set; }
        public Accidentdesccode accidentDescCode { get; set; }
        public Accidenttypecode accidentTypeCode { get; set; }
        public string dateFddotRpt { get; set; }
        public string dateStdotRpt { get; set; }
        public bool inTrafficFlag { get; set; }
        public Policeagencyeid policeAgencyEid { get; set; }
        public bool preventableFlag { get; set; }
        public bool reportableFlag { get; set; }
        public string stDotRptId { get; set; }
        public int estCollection { get; set; }
        public string dateRptdToRm { get; set; }
        public int duration { get; set; }
        public Filingstateid filingStateId { get; set; }
        public Mcoeid mcoEid { get; set; }
        public int rateTableId { get; set; }
        public Planid planId { get; set; }
        public int classRowId { get; set; }
        public string disabilFromDate { get; set; }
        public string disabilToDate { get; set; }
        public string benefitsStart { get; set; }
        public string benefitsThrough { get; set; }
        public Distypecode disTypeCode { get; set; }
        public string benCalcPayStart { get; set; }
        public string benCalcPayTo { get; set; }
        public int taxFlags { get; set; }
        public int pensionAmt { get; set; }
        public int ssAmt { get; set; }
        public int compRate { get; set; }
        public int otherAmt { get; set; }
        public int otherOffset1 { get; set; }
        public int otherOffset2 { get; set; }
        public int otherOffset3 { get; set; }
        public int postTaxDed1 { get; set; }
        public int postTaxDed2 { get; set; }
        public Aiacode12 aiaCode12 { get; set; }
        public Aiacode34 aiaCode34 { get; set; }
        public Aiacode56 aiaCode56 { get; set; }
        public bool spHandlingFlag { get; set; }
        public bool selfInsuredFlag { get; set; }
        public string dateOfDiscovery { get; set; }
        public string reportNumber { get; set; }
        public bool adjustPrintDatesFlag { get; set; }
        public Catastrophecode catastropheCode { get; set; }
        public int catastropheRowId { get; set; }
        public int catstropheDecisionFlag { get; set; }
        public bool confRecFlag { get; set; }
        public Claimdescriptioncode claimDescriptionCode { get; set; }
        public string lossDescription { get; set; }
        public string lossDescription_HTMLComments { get; set; }
        public Claimcategorycode claimCategoryCode { get; set; }
        public string noticeDate { get; set; }
        public string errorDate { get; set; }
        public string underlyingLossDate { get; set; }
        public Insuredclaimdepteid insuredClaimDeptEid { get; set; }
        public Cluefaultind clueFaultInd { get; set; }
        public Cluelossofdispos clueLossofDispos { get; set; }
        public Cluereportingstatus clueReportingStatus { get; set; }
        public Clueremovalreason clueRemovalReason { get; set; }
        public Acord[] acord { get; set; }
        public object propertyClaim { get; set; }
        public string docRetentionDate { get; set; }
        public bool exclDeletionFlag { get; set; }
        public bool minorInvolvedFlag { get; set; }
        public object jurisdictionals { get; set; }
        public Claimsupervisorid[] claimSupervisorId { get; set; }
        public Customhierarchy customHierarchy { get; set; }
        public Supplemental[] supplementals { get; set; }
        public string dttmRcdLastUpd { get; set; }
        public Link[] links { get; set; }
        public Associatedentity[] associatedEntities { get; set; }
        public Sysexdata sysExData { get; set; }
    }

    public class Proprowid
    {
        public int id { get; set; }
        public string desc { get; set; }
    }

    public class Claimstatuscode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Lineofbuscode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Claimtypecode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Methodclosedcode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Policylobcode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Primarypolicyid
    {
        public int id { get; set; }
        public string desc { get; set; }
    }

    public class Primarypolicyidenh
    {
        public int id { get; set; }
        public string desc { get; set; }
    }

    public class Servicecode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Accidentdesccode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Accidenttypecode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Policeagencyeid
    {
        public int id { get; set; }
        public string desc { get; set; }
    }

    public class Filingstateid
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Mcoeid
    {
        public int id { get; set; }
        public string desc { get; set; }
    }

    public class Planid
    {
        public int id { get; set; }
        public string desc { get; set; }
    }

    public class Distypecode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Aiacode12
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Aiacode34
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Aiacode56
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Catastrophecode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Claimdescriptioncode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Claimcategorycode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Insuredclaimdepteid
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Cluefaultind
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Cluelossofdispos
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Cluereportingstatus
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Clueremovalreason
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Customhierarchy
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    //public class Event
    //{
    //    public int eventId { get; set; }
    //    public string countyOfInjury { get; set; }
    //    public string eventNumber { get; set; }
    //    public Eventtypecode eventTypeCode { get; set; }
    //    public Eventstatuscode eventStatusCode { get; set; }
    //    public Eventindcode eventIndCode { get; set; }
    //    public string eventDescription { get; set; }
    //    public string briefDesc { get; set; }
    //    public Depteid deptEid { get; set; }
    //    public Deptinvolvedeid deptInvolvedEid { get; set; }
    //    public string addr1 { get; set; }
    //    public string addr2 { get; set; }
    //    public string addr3 { get; set; }
    //    public string addr4 { get; set; }
    //    public string city { get; set; }
    //    public Stateid stateId { get; set; }
    //    public string zipCode { get; set; }
    //    public Countrycode countryCode { get; set; }
    //    public string locationAreaDesc { get; set; }
    //    public Primaryloccode primaryLocCode { get; set; }
    //    public Locationtypecode locationTypeCode { get; set; }
    //    public bool onPremiseFlag { get; set; }
    //    public int noOfInjuries { get; set; }
    //    public int noOfFatalities { get; set; }
    //    public Causecode causeCode { get; set; }
    //    public string dateOfEvent { get; set; }
    //    public string timeOfEvent { get; set; }
    //    public string dateReported { get; set; }
    //    public string timeReported { get; set; }
    //    public Rptdbyeid rptdByEid { get; set; }
    //    public string dateRptdToRm { get; set; }
    //    public string dateToFollowUp { get; set; }
    //    public int accountId { get; set; }
    //    public string datePhysAdvised { get; set; }
    //    public string timePhysAdvised { get; set; }
    //    public bool treatmentGiven { get; set; }
    //    public bool releaseSigned { get; set; }
    //    public bool deptHeadAdvised { get; set; }
    //    public string physNotes { get; set; }
    //    public string dateCarrierNotif { get; set; }
    //    public string injuryFromDate { get; set; }
    //    public string injuryToDate { get; set; }
    //    public string eventDescription_HTMLComments { get; set; }
    //    public string locationAreaDesc_HTMLComments { get; set; }
    //    public bool requireIntervention { get; set; }
    //    public bool confRecFlag { get; set; }
    //    public Catastrophenumber catastropheNumber { get; set; }
    //    public object[] eventXAction { get; set; }
    //    public object[] eventXOutcome { get; set; }
    //    public object eventQM { get; set; }
    //    public object reporterEntity { get; set; }
    //    public object supplementals { get; set; }
    //    public object dttmRcdLastUpd { get; set; }
    //    public object[] links { get; set; }
    //    public object[] associatedEntities { get; set; }
    //    public object sysExData { get; set; }
    //}

    public class Acord
    {
        public string caption { get; set; }
        public string fieldName { get; set; }
        public string fieldType { get; set; }
        public object value { get; set; }
        public object values { get; set; }
    }

    public class Claimsupervisorid
    {
        public int groupID { get; set; }
        public int userID { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }

}
