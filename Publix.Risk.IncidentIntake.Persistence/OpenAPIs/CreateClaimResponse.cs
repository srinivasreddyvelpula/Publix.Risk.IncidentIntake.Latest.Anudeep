namespace Publix.Risk.IncidentIntake.Persistence.OpenAPIs
{
    public class CreateClaimResponse
    {
        public object[] errors { get; set; }
        public ClaimViewmodel viewModel { get; set; }
        public View view { get; set; }
    }

    public class ClaimViewmodel
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
        public float estCollection { get; set; }
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
        public float pensionAmt { get; set; }
        public float ssAmt { get; set; }
        public float compRate { get; set; }
        public float otherAmt { get; set; }
        public float otherOffset1 { get; set; }
        public float otherOffset2 { get; set; }
        public float otherOffset3 { get; set; }
        public float postTaxDed1 { get; set; }
        public float postTaxDed2 { get; set; }
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

    public class Currencytype
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

    public class Sysexdata
    {
        public string eventId { get; set; }
        public string openCatestrophy { get; set; }
        public string claimLetterTmplId { get; set; }
        public string downloadedEntitiesIds { get; set; }
        public string downloadedVehicleIds { get; set; }
        public string downloadedPropertyIds { get; set; }
        public string checkPolicyValidation { get; set; }
        public string hdnEditClaimEvtDate { get; set; }
        public string hdnselectedpermsusers { get; set; }
        public string hidden_DataChanged { get; set; }
        public string useAdvancedClaim { get; set; }
        public string newClaim { get; set; }
        public string allCodes { get; set; }
        public string currentAdjuster { get; set; }
        public string eventOnPremiseChecked { get; set; }
        public string subTitle { get; set; }
        public string diaryMessage { get; set; }
        public string claimNumber { get; set; }
        public string dupeoverride { get; set; }
        public string statusDateChg { get; set; }
        public object statusReason { get; set; }
        public string systemcurdate { get; set; }
        public string backdtClaimSetting { get; set; }
        public string displayBackButton { get; set; }
        public string closeDiary { get; set; }
        public string containsOpenDiaries { get; set; }
        public string deleteAutoCheck { get; set; }
        public string claimStatusCode { get; set; }
        public string containsAutoChecks { get; set; }
        public string deleteAllClaimDiaries { get; set; }
        public string insuredClaimDeptFlag { get; set; }
        public string oH_FACILITY_EID { get; set; }
        public string oH_LOCATION_EID { get; set; }
        public string oH_DIVISION_EID { get; set; }
        public string oH_REGION_EID { get; set; }
        public string oH_OPERATION_EID { get; set; }
        public string oH_COMPANY_EID { get; set; }
        public string oH_CLIENT_EID { get; set; }
        public string useLegacyComments { get; set; }
        public string claimRptDateType { get; set; }
        public string isAutoPopulateDpt { get; set; }
        public string claimPolicyListCodeId { get; set; }
        public string claimPolicyList { get; set; }
        public string pointClaimEventSetting { get; set; }
        public string baseCurrencyType { get; set; }
        public string policybtn { get; set; }
        public string reserveExistOnPolicy { get; set; }
        public string policyFromStaging { get; set; }
        public string transStatus { get; set; }
        public string makePolicyLOBMandatory { get; set; }
        public string catastropheNumber { get; set; }
        public string catastropheDescription { get; set; }
        public string addPolicyInsuredAsClaimant { get; set; }
        public string addNotesForExcludedDriver { get; set; }
        public string irdrawer { get; set; }
        public string irfiletype { get; set; }
        public string generateFUPFile { get; set; }
        public string updateflag { get; set; }
        public string internalCarrierPolicySystemId { get; set; }
        public string filterfinancialkeywithPolicyLOB { get; set; }
        public Event _event { get; set; }
        public string sysFormIdName { get; set; }
        public string sysSid { get; set; }
        public string sysRequired { get; set; }
        public string sysNotRequired { get; set; }
        public string numOfPolicy { get; set; }
        public string showPolicyPopUp { get; set; }
        public object statusApprovedBy { get; set; }
    }

    public class Event
    {
        public int eventId { get; set; }
        public string countyOfInjury { get; set; }
        public string eventNumber { get; set; }
        public Eventtypecode eventTypeCode { get; set; }
        public Eventstatuscode eventStatusCode { get; set; }
        public Eventindcode eventIndCode { get; set; }
        public string eventDescription { get; set; }
        public string briefDesc { get; set; }
        public Depteid deptEid { get; set; }
        public Deptinvolvedeid deptInvolvedEid { get; set; }
        public string addr1 { get; set; }
        public string addr2 { get; set; }
        public string addr3 { get; set; }
        public string addr4 { get; set; }
        public string city { get; set; }
        public Stateid stateId { get; set; }
        public string zipCode { get; set; }
        public Countrycode countryCode { get; set; }
        public string locationAreaDesc { get; set; }
        public Primaryloccode primaryLocCode { get; set; }
        public Locationtypecode locationTypeCode { get; set; }
        public bool onPremiseFlag { get; set; }
        public int noOfInjuries { get; set; }
        public int noOfFatalities { get; set; }
        public Causecode causeCode { get; set; }
        public string dateOfEvent { get; set; }
        public string timeOfEvent { get; set; }
        public string dateReported { get; set; }
        public string timeReported { get; set; }
        public Rptdbyeid rptdByEid { get; set; }
        public string dateRptdToRm { get; set; }
        public string dateToFollowUp { get; set; }
        public int accountId { get; set; }
        public string datePhysAdvised { get; set; }
        public string timePhysAdvised { get; set; }
        public bool treatmentGiven { get; set; }
        public bool releaseSigned { get; set; }
        public bool deptHeadAdvised { get; set; }
        public string physNotes { get; set; }
        public string dateCarrierNotif { get; set; }
        public string injuryFromDate { get; set; }
        public string injuryToDate { get; set; }
        public string eventDescription_HTMLComments { get; set; }
        public string locationAreaDesc_HTMLComments { get; set; }
        public bool requireIntervention { get; set; }
        public bool confRecFlag { get; set; }
        public Catastrophenumber catastropheNumber { get; set; }
        public object[] eventXAction { get; set; }
        public object[] eventXOutcome { get; set; }
        public object eventQM { get; set; }
        public object reporterEntity { get; set; }
        public object supplementals { get; set; }
        public object dttmRcdLastUpd { get; set; }
        public object[] links { get; set; }
        public object[] associatedEntities { get; set; }
        public object sysExData { get; set; }
    }

    public class Eventtypecode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Eventstatuscode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Eventindcode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Depteid
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Deptinvolvedeid
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Stateid
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Countrycode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Primaryloccode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Locationtypecode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Causecode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Rptdbyeid
    {
        public int id { get; set; }
        public string desc { get; set; }
    }

    public class Catastrophenumber
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

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

    public class Supplemental
    {
        public string caption { get; set; }
        public string fieldName { get; set; }
        public string fieldType { get; set; }
        public object value { get; set; }
        public object[] values { get; set; }
    }

    public class Link
    {
        public string href { get; set; }
        public string rel { get; set; }
        public string method { get; set; }
        public int recordId { get; set; }
    }

    public class Associatedentity
    {
        public string href { get; set; }
        public string rel { get; set; }
        public string method { get; set; }
        public int recordId { get; set; }
    }

    public class View
    {
        public Form form { get; set; }
    }

    public class Form
    {
        public string name { get; set; }
        public string title { get; set; }
        public string sid { get; set; }
        public string topbuttons { get; set; }
        public string supp { get; set; }
        public string isTabView { get; set; }
        public string _readonly { get; set; }
        public string helpmsg { get; set; }
        public Subtitle subtitle { get; set; }
        public Child[] child { get; set; }
        public Siblinglookup siblinglookup { get; set; }
        public object[] suppgrid { get; set; }
        public Toolbar toolbar { get; set; }
        public Group group { get; set; }
        public bool displaysummary { get; set; }
    }

    public class Subtitle
    {
        public string title { get; set; }
    }

    public class Siblinglookup
    {
        public string type { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string rel { get; set; }
        public string icon { get; set; }
        public string _class { get; set; }
    }

    public class Toolbar
    {
        public Button[] button { get; set; }
    }

    public class Button
    {
        public string type { get; set; }
        public string title { get; set; }
        public string icon { get; set; }
        public string _class { get; set; }
        public string isUXField { get; set; }
        public string parentcontrolfield { get; set; }
        public string name { get; set; }
    }

    public class Group
    {
        public Section[] section { get; set; }
    }

    public class Section
    {
        public string name { get; set; }
        public Control[] Controls { get; set; }
        public Internalcontrol[] internalControls { get; set; }
    }

    public class Control
    {
        public string name { get; set; }
        public string title { get; set; }
        public string selected { get; set; }
        public string type { get; set; }
        public bool display { get; set; }
        public Displaycolumn[] displaycolumn { get; set; }
    }

    public class Displaycolumn
    {
        public Row[] row { get; set; }
    }

    public class Row
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string firstfield { get; set; }
        public string tabindex { get; set; }
        public string title { get; set; }
        public string maxlength { get; set; }
        public string required { get; set; }
        public string fieldmark { get; set; }
        public string _ref { get; set; }
        public string _readonly { get; set; }
        public string onchangefunctionname { get; set; }
        public Params _params { get; set; }
        public string codetable { get; set; }
        public string orglevel { get; set; }
        public string instructions { get; set; }
        public string creatable { get; set; }
        public string detailtype { get; set; }
        public string formatas { get; set; }
        public string CurrencyMode { get; set; }
        public string parentControl { get; set; }
        public string Width { get; set; }
        public string showmediaviewbutton { get; set; }
        public string showpolicyinpoint { get; set; }
        public string idref { get; set; }
        public string enablefornew { get; set; }
        public string linktobutton { get; set; }
        public string button { get; set; }
        public string param { get; set; }
        public string onclick { get; set; }
        public string Columns { get; set; }
        public string rows { get; set; }
        public string value { get; set; }
        public string locevtdesc { get; set; }
        public string refhtml { get; set; }
        public string AllowFormatText { get; set; }
        public string cols { get; set; }
        public string tableid { get; set; }
        public string min { get; set; }
        public string filter { get; set; }
        public string fieldtype { get; set; }
        public string _class { get; set; }
        public string GroupAssoc { get; set; }
        public string entityNev { get; set; }
        public string entitytype { get; set; }
    }

    public class Params
    {
        public string tableName { get; set; }
        public string key { get; set; }
        public string orghlevel { get; set; }
        public string detailtype { get; set; }
        public string viewid { get; set; }
        public string fieldmark { get; set; }
        public string lookupType { get; set; }
    }

    public class Internalcontrol
    {
        public string type { get; set; }
        public string name { get; set; }
        public string _ref { get; set; }
        public string value { get; set; }
    }

    public class Child
    {
        public string title { get; set; }
        public string name { get; set; }
        public string visible { get; set; }
        public string rel { get; set; }
        public string icon { get; set; }
        public string _class { get; set; }
        public string route { get; set; }
    }

}
