namespace Publix.Risk.IncidentIntake.Domain.ValueObjects
{
    public class InvolvementType : Enumeration<InvolvementType, int>
    {
        public string ShortCode { get; }

        private InvolvementType(int value, string description, string shortCode) : base(value, description)
        {
            ShortCode = shortCode;
        }


        public static readonly InvolvementType Witness = new InvolvementType(23528, "Witness", "W01");
        public static readonly InvolvementType InjuredCustomer = new InvolvementType(23511, "Injured Customer", "I02");
        public static readonly InvolvementType InjuredAssociate = new InvolvementType(23510, "Injured Associate", "I01");
        public static readonly InvolvementType CQARepresentative = new InvolvementType(23505, "CQA Representative", "C01");
        public static readonly InvolvementType Driver = new InvolvementType(23506, "Driver", "D01");
        public static readonly InvolvementType FilingPharmacist = new InvolvementType(23507, "Filing Pharmacist/Tech", "F01");
        public static readonly InvolvementType InjuredVendor = new InvolvementType(23513, "Injured Vendor", "I04");
        public static readonly InvolvementType ManagerInCharge = new InvolvementType(23517, "Manager In Charge", "M01");
        public static readonly InvolvementType ManagerReportedTo = new InvolvementType(23518, "Manager Reported To", "M02");
        public static readonly InvolvementType LastInspector = new InvolvementType(23515, "Last Inspector", "L01");
        public static readonly InvolvementType LastStockedBy = new InvolvementType(23516, "Last Stocked By", "L02");
        public static readonly InvolvementType OtherPatient = new InvolvementType(23519, "Other Patient", "O01");
        public static readonly InvolvementType Passenger = new InvolvementType(23520, "Passenger", "P01");
        public static readonly InvolvementType Pedestrian = new InvolvementType(23521, "Pedestrian", "P02");
        public static readonly InvolvementType PersonCompletingForm = new InvolvementType(23522, "Person Completing Form", "P03");
        public static readonly InvolvementType PharmacistReportedTo = new InvolvementType(160933, "Pharmacist Reported To", "P035");
        public static readonly InvolvementType PharmacySupervisor = new InvolvementType(23523, "Pharmacy Supervisor", "P04");
        public static readonly InvolvementType PrimaryCustomer = new InvolvementType(23524, "Primary Customer", "P05");
        public static readonly InvolvementType PrimaryPatient = new InvolvementType(23525, "Primary Patient", "P06");
        public static readonly InvolvementType PropertyOwner = new InvolvementType(158167, "Primary Owner", "P07");
        public static readonly InvolvementType VendorInvolved = new InvolvementType(23527, "Vendor Involved", "V01");
        public static readonly InvolvementType AdverseDriver = new InvolvementType(23503, "Adverse Driver", "A01");
        public static readonly InvolvementType AdverseOwner = new InvolvementType(158166, "Adverse Owner", "A015");
        public static readonly InvolvementType AdversePassenger = new InvolvementType(23504, "Adverse Passenger", "A02");
        public static readonly InvolvementType FirstAidResp = new InvolvementType(23508, "First Aid Responder", "F02");
        public static readonly InvolvementType FirstOnScene = new InvolvementType(23509, "First On Scene", "F03");
        public static readonly InvolvementType InjuredTempAssociate = new InvolvementType(23512, "Injured Temp Associate", "I03");
        public static readonly InvolvementType InvolvedInIncident = new InvolvementType(23514, "Involved In Incident", "I05");
        public static readonly InvolvementType ResponsibileForArea = new InvolvementType(23526, "Responsible for Area/Section", "R01");
        public static readonly InvolvementType TenderedVendor = new InvolvementType(23527, "Tendered Vendor", "T01");


    }
}
