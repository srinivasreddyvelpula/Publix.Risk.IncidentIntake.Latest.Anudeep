namespace Publix.Risk.IncidentIntake.Domain.ValueObjects
{
    public class LOBCodes : Enumeration<LOBCodes, int>
    {
        public LOBCodes() : base(3, "WC")
        { }


        private LOBCodes(int value, string description) : base(value, description)
        { }


        public static readonly LOBCodes GC = new LOBCodes(1, "GC");
        public static readonly LOBCodes VA = new LOBCodes(2, "VA");
        public static readonly LOBCodes WC = new LOBCodes(3, "WC");
        public static readonly LOBCodes DI = new LOBCodes(4, "DI");
        public static readonly LOBCodes PC = new LOBCodes(5, "PC");

    }
}
