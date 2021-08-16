namespace Publix.Risk.IncidentIntake.Domain.ValueObjects
{
    public class EventType : Enumeration<EventType, int>
    {
        public EventType() : base(2316, "WC")
        { }


        private EventType(int value, string description) : base(value, description)
        { }


        public static readonly EventType WorkersCompensation = new EventType(2316, "WC");
        public static readonly EventType AutoCDL = new EventType(2315, "AU");       // Auto
        public static readonly EventType AutoNoCDL = new EventType(460250, "AUNCDL");   // Fleet
        public static readonly EventType QRE = new EventType(505, "QRE");
        public static readonly EventType CustomerIncident = new EventType(2317, "CI");
        public static readonly EventType PropertyDamage = new EventType(2320, "PD");
        public static readonly EventType CartDamage = new EventType(2321, "CD");
        public static readonly EventType CQA = new EventType(2521, "CQA");

    }
}
