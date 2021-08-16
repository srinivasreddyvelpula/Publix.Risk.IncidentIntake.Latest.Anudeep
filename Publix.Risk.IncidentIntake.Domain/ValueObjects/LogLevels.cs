namespace Publix.Risk.IncidentIntake.Domain.ValueObjects
{
    public class LogLevels : Enumeration<LogLevels, int>
    {
        public LogLevels(string description) : base(LogLevels.FromDescription(description).Value, description)
        {
        }


        private LogLevels(int value, string description) : base(value, description)
        { }


        public static readonly LogLevels None = new LogLevels(0, "None");
        public static readonly LogLevels Debug = new LogLevels(1, "Debug");
        public static readonly LogLevels Info = new LogLevels(2, "Info");
        public static readonly LogLevels Warning = new LogLevels(3, "Warn");
        public static readonly LogLevels Error = new LogLevels(4, "Error");
        public static readonly LogLevels Verbose = new LogLevels(5, "Verbose");    // Not a real log level but includes all levels
                                                                                   // regardless of whether or not the standard is to block it
                                                                                   // For example, Debug isn't normally written, but if
                                                                                   // Verbose is set, it will be written anyways (override).


        public static bool ShouldLog(LogLevels systemLevel, LogLevels requestedLogLevel)
        {
            bool log = ((requestedLogLevel.Value & systemLevel.Value) == requestedLogLevel.Value) || systemLevel.Value == LogLevels.Verbose.Value;

            return log;
        }
    }
}
