namespace Publix.Risk.IncidentIntake.Domain.ValueObjects
{
    public class ClaimType : Enumeration<ClaimType, int>
    {
        public string ShortCode { get; }


        private ClaimType(int value, string description, string code) : base((int)value, description)
        {
            ShortCode = code;
        }


        public static readonly ClaimType WorkersCompensation = new ClaimType(241, "Workers Compenstation", "WC");
        public static readonly ClaimType CustomerInjury = new ClaimType(242, "General Liability", "GC");
        public static readonly ClaimType QRE = new ClaimType(243, "QRE", "QR");
        public static readonly ClaimType AutoSafety = new ClaimType(240, "Auto Safety", "AU");
        public static readonly ClaimType FleetSafety = new ClaimType(244, "Fleet Safety", "FL");
        public static readonly ClaimType CartDamage = new ClaimType(245, "Property Damage", "PD");
        public static readonly ClaimType ProductClaim = new ClaimType(246, "CQA", "CQ");
    }
}
