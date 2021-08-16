using Publix.Risk.IncidentIntake.Infrastructure.Core;
using System;

namespace Publix.Risk.IncidentIntake.Domain.Core.Model
{
    public class LogEntry
    {
        public int Log_ID { get; set; }
        public LogLevels Level { get; set; }
        public string Message { get; set; }
        public string MachineName { get; set; }
        public string Caller { get; set; }
        public string AppName { get; set; }
        public string Detail { get; set; }
        public string Win32ThreadId { get; set; }
        public int Priority { get; set; }
        public string Severity { get; set; }
        public int EventId { get; set; }
        public DateTime Timestamp { get; set; }
        public int ProcessId { get; set; }
        public string ThreadName { get; set; }
    }
}
