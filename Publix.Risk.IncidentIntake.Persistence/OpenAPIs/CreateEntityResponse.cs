namespace Publix.Risk.IncidentIntake.Persistence.AssureClaims
{
    public class CreateEntityResponse
    {
        public object[] errors { get; set; }
        public EntityViewModel viewModel { get; set; }
        public FormView view { get; set; }
    }

    public class EntityViewModel
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

}
