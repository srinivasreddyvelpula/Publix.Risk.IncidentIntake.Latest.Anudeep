namespace Publix.Risk.IncidentIntake.Persistence.AssureClaims
{
    public class CreateEventResponse
    {
        public object[] errors { get; set; }
        public EventViewModel viewModel { get; set; }
        public FormView view { get; set; }
    }

    public class EventViewModel
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
        public Eventqm eventQM { get; set; }
        public Reporterentity reporterEntity { get; set; }
        public Supplemental1[] supplementals { get; set; }
        public string dttmRcdLastUpd { get; set; }
        public Link[] links { get; set; }
        public Associatedentity[] associatedEntities { get; set; }
        public Sysexdata sysExData { get; set; }
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

    public class Eventqm
    {
        public int eventId { get; set; }
        public string medCaseNumber { get; set; }
        public Medfilecode medFileCode { get; set; }
        public Medindcode medIndCode { get; set; }
        public Irstatuscode irStatusCode { get; set; }
        public Irrevieweruid[] irReviewerUid { get; set; }
        public string irReviewerName { get; set; }
        public Irdetermcode irDetermCode { get; set; }
        public string irReviewDate { get; set; }
        public string irFollowUpDate { get; set; }
        public string irComments { get; set; }
        public string irRecActions { get; set; }
        public Pastatuscode paStatusCode { get; set; }
        public Pareviewereid paReviewerEid { get; set; }
        public Padetermcode paDetermCode { get; set; }
        public string paReviewDate { get; set; }
        public string paFollowUpDate { get; set; }
        public string paComments { get; set; }
        public string paRecActions { get; set; }
        public Cdstatuscode cdStatusCode { get; set; }
        public Cdcommitteecode cdCommitteeCode { get; set; }
        public Cddepteid cdDeptEid { get; set; }
        public Cddetermcode cdDetermCode { get; set; }
        public string cdReviewDate { get; set; }
        public string cdFollowUpDate { get; set; }
        public string cdComments { get; set; }
        public string cdRecActions { get; set; }
        public Qmstatuscode qmStatusCode { get; set; }
        public Qmrevieweruid[] qmReviewerUid { get; set; }
        public string qmReviewerName { get; set; }
        public Qmdetermcode qmDetermCode { get; set; }
        public string qmReviewDate { get; set; }
        public string qmCloseDate { get; set; }
        public string qmComments { get; set; }
        public string qmRecActions { get; set; }
        public object supplementals { get; set; }
        public object dttmRcdLastUpd { get; set; }
        public object[] links { get; set; }
        public object[] associatedEntities { get; set; }
        public object sysExData { get; set; }
    }

    public class Medfilecode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Medindcode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Irstatuscode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Irdetermcode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Pastatuscode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Pareviewereid
    {
        public int id { get; set; }
        public string desc { get; set; }
    }

    public class Padetermcode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Cdstatuscode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Cdcommitteecode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Cddepteid
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Cddetermcode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Qmstatuscode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Qmdetermcode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Irrevieweruid
    {
        public int groupID { get; set; }
        public int userID { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }

    public class Qmrevieweruid
    {
        public int groupID { get; set; }
        public int userID { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }

    public class Reporterentity
    {
        public Businesstypecode businessTypeCode { get; set; }
        public string county { get; set; }
        public string natureOfBusiness { get; set; }
        public Siccode sicCode { get; set; }
        public string sicCodeDesc { get; set; }
        public string wcFillingNumber { get; set; }
        public int entityId { get; set; }
        public int entityTableId { get; set; }
        public string firstName { get; set; }
        public string alsoKnownAs { get; set; }
        public string abbreviation { get; set; }
        public Costcentercode costCenterCode { get; set; }
        public string addr1 { get; set; }
        public string addr2 { get; set; }
        public string city { get; set; }
        public Countrycode1 countryCode { get; set; }
        public Stateid1 stateId { get; set; }
        public string zipCode { get; set; }
        public Parenteid parentEid { get; set; }
        public string taxId { get; set; }
        public string contact { get; set; }
        public string comments { get; set; }
        public Emailtypecode emailTypeCode { get; set; }
        public string emailAddress { get; set; }
        public Sexcode sexCode { get; set; }
        public string birthDate { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string faxNumber { get; set; }
        public string effStartDate { get; set; }
        public string effEndDate { get; set; }
        public Parent1099eid parent1099EID { get; set; }
        public bool entity1099Reportable { get; set; }
        public string middleName { get; set; }
        public string title { get; set; }
        public Naicscode naicsCode { get; set; }
        public bool freezePayments { get; set; }
        public Organizationtype organizationType { get; set; }
        public string npiNumber { get; set; }
        public Timezonecode timeZoneCode { get; set; }
        public Prefix prefix { get; set; }
        public Suffixcommon suffixCommon { get; set; }
        public string suffixLegal { get; set; }
        public string legalName { get; set; }
        public string referenceNumber { get; set; }
        public string legacyUniqueIdentifier { get; set; }
        public string effectiveDate { get; set; }
        public string expirationDate { get; set; }
        public Adjustereid adjusterEId { get; set; }
        public int idType { get; set; }
        public string lastName { get; set; }
        public string addr3 { get; set; }
        public string addr4 { get; set; }
        public bool deletedFlag { get; set; }
        public string triggerDateField { get; set; }
        public bool overrideOfacCheck { get; set; }
        public Rmuserid[] rmUserId { get; set; }
        public bool timeZoneTracking { get; set; }
        public string emailPassword { get; set; }
        public int hbrFeeLines { get; set; }
        public float hbrAmt { get; set; }
        public int mbrFeeLines { get; set; }
        public float mbrAmt { get; set; }
        public bool mmseatinEditFlag { get; set; }
        public bool autoDiscFlg { get; set; }
        public float autoDiscount { get; set; }
        public string htmlComments { get; set; }
        public string rejectReasonText { get; set; }
        public string rejectReasonText_HTMLComments { get; set; }
        public Entityapprovalstatuscode entityApprovalStatusCode { get; set; }
        public Currencytype currencyType { get; set; }
        public string clientSequenceNumber { get; set; }
        public Nametype nameType { get; set; }
        public string ncciCarrierCode { get; set; }
        public string dunsNumber { get; set; }
        public string ausTetraNumber { get; set; }
        public string experianBIN { get; set; }
        public bool hasAcceptedBankinginfo { get; set; }
        public object combinedPayment { get; set; }
        public object instructions { get; set; }
        public bool useEntityRole { get; set; }
        public Supplemental[] supplementals { get; set; }
        public object dttmRcdLastUpd { get; set; }
        public object[] links { get; set; }
        public object[] associatedEntities { get; set; }
        public object sysExData { get; set; }
    }

    public class Businesstypecode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Siccode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Costcentercode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Countrycode1
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Stateid1
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Parenteid
    {
        public int id { get; set; }
        public string desc { get; set; }
    }

    public class Emailtypecode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Sexcode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Parent1099eid
    {
        public int id { get; set; }
        public string desc { get; set; }
    }

    public class Naicscode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Organizationtype
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Timezonecode
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Prefix
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Suffixcommon
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Adjustereid
    {
        public int id { get; set; }
        public string desc { get; set; }
    }

    public class Entityapprovalstatuscode
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

    public class Nametype
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Rmuserid
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

    public class Sysexdata
    {
        public string newEvent { get; set; }
        public Eventcat eventCat { get; set; }
        public string subTitle { get; set; }
        public string allCodes { get; set; }
        public string closeDiary { get; set; }
        public bool containsOpenDiaries { get; set; }
        public string isAnyClaimHavePolicy { get; set; }
        public string eventOnPremiseChecked { get; set; }
        public string oH_FACILITY_EID { get; set; }
        public string oH_LOCATION_EID { get; set; }
        public string oH_DIVISION_EID { get; set; }
        public string oH_REGION_EID { get; set; }
        public string oH_OPERATION_EID { get; set; }
        public string oH_COMPANY_EID { get; set; }
        public string oH_CLIENT_EID { get; set; }
        public string useLegacyComments { get; set; }
        public string hdnselectedpermsusers { get; set; }
        public string psO_EVENT_TYPES { get; set; }
        public string evtPsoRowId { get; set; }
        public string patPsoRowId { get; set; }
        public string isAutoPopulateDpt { get; set; }
        public string sysFormIdName { get; set; }
        public string sysSid { get; set; }
        public string sysRequired { get; set; }
        public string sysNotRequired { get; set; }
    }

    public class Eventcat
    {
        public int id { get; set; }
        public string shortCode { get; set; }
        public string desc { get; set; }
        public string codeTable { get; set; }
    }

    public class Supplemental1
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

    public class FormView
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
        public object[] suppgrid { get; set; }
        public Toolbar toolbar { get; set; }
        public Group group { get; set; }
        public bool displaysummary { get; set; }
    }

    public class Subtitle
    {
        public string title { get; set; }
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
        public string name { get; set; }
        public string isUXField { get; set; }
        public string parentcontrolfield { get; set; }
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
        public string tabindex { get; set; }
        public string firstfield { get; set; }
        public string title { get; set; }
        public string maxlength { get; set; }
        public string required { get; set; }
        public string value { get; set; }
        public string _ref { get; set; }
        public string _readonly { get; set; }
        public Params _params { get; set; }
        public string codetable { get; set; }
        public string codeid { get; set; }
        public string onchangefunctionname { get; set; }
        public string parentnode { get; set; }
        public string orglevel { get; set; }
        public string refhtml { get; set; }
        public string locevtdesc { get; set; }
        public string uxtabindex { get; set; }
        public string AllowFormatText { get; set; }
        public string cols { get; set; }
        public string rows { get; set; }
        public string onclick { get; set; }
        public string countrymappedid { get; set; }
        public string min { get; set; }
        public string tableid { get; set; }
        public string fieldmark { get; set; }
        public string creatable { get; set; }
        public string fullrow { get; set; }
        public string param { get; set; }
        public string pagetomove { get; set; }
        public string icon { get; set; }
        public string _class { get; set; }
        public string countref { get; set; }
        public string activeimage { get; set; }
        public string moimage { get; set; }
        public string disabled { get; set; }
        public string fieldtype { get; set; }
        public string GroupAssoc { get; set; }
        public string entityNev { get; set; }
        public string entitytype { get; set; }
        public string searchable { get; set; }
    }

    public class Params
    {
        public string tableName { get; set; }
        public string key { get; set; }
        public string orghlevel { get; set; }
        public string fieldmark { get; set; }
        public string lookupType { get; set; }
        public string viewid { get; set; }
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
        public string route { get; set; }
        public string rel { get; set; }
        public string icon { get; set; }
        public string _class { get; set; }
        public string hideinux { get; set; }
    }

}
