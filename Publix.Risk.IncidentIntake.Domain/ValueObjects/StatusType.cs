namespace Publix.Risk.IncidentIntake.Domain.ValueObjects
{
    public class StatusType : Enumeration<StatusType, int>
    {
        public string? ShortCode { get; }


        public StatusType() : base(0, null)
        {
            ShortCode = null;
        }


        private StatusType(int value, string? description, string? code) : base((int)value, description)
        {
            ShortCode = code;
        }


        public static readonly StatusType None = new StatusType(0, null, null);
        public static readonly StatusType Open = new StatusType(12, "Open", "O");
        public static readonly StatusType Close = new StatusType(13, "Close", "C");
    }
}
