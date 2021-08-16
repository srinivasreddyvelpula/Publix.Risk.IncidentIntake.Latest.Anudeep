using Newtonsoft.Json;
using Publix.Risk.IncidentIntake.Domain;
using Publix.Risk.IncidentIntake.Domain.Interfaces;
using Publix.Risk.IncidentIntake.Infrastructure;
using System;
using System.Runtime.CompilerServices;

namespace Publix.Risk.IncidentIntake.Application
{
    public class DbLogger : ILogger
    {
        private IPBXContext pbx { get; }


        public DbLogger(IPBXContext context, IConfig config)
        {
            Level = LogLevels.FromDescription(config.LogLevel);
            pbx = context;
        }


        public LogLevels Level { get; }


        public int Debug(string message, IMetadata data, [CallerMemberName] string caller = null)
        {
            LogEntry entry = new LogEntry()
            {
                Level = LogLevels.Debug,
                Message = message,
                Detail = JsonConvert.SerializeObject(data),
                Timestamp = DateTime.Now,
                Caller = caller,
                AppName = "Publix.Risk.IncidentIntake",
                MachineName = Environment.MachineName,
                EventId = 0,
                Severity = Level.Description,
                Priority = 9 - Level.Value
            };

            return Log(entry);
        }


        public int Error(string message, IMetadata data, [CallerMemberName] string caller = null)
        {
            LogEntry entry = new LogEntry()
            {
                Level = LogLevels.Error,
                Message = message,
                Detail = JsonConvert.SerializeObject(data),
                Timestamp = DateTime.Now,
                Caller = caller,
                AppName = "Publix.Risk.IncidentIntake",
                MachineName = Environment.MachineName,
                EventId = 1,
                Severity = Level.Description,
                Priority = 9 - Level.Value
            };

            return Log(entry);
        }


        public int Error(Exception ex, IMetadata data, [CallerMemberName] string caller = null)
        {
            LogEntry entry = new LogEntry()
            {
                Level = LogLevels.Info,
                Message = ex.Message,
                Detail = ex.ToString() + "\r\n" + JsonConvert.SerializeObject(data),
                Timestamp = DateTime.Now,
                Caller = caller,
                AppName = "Publix.Risk.IncidentIntake",
                MachineName = Environment.MachineName,
                ThreadName = ex.Source,
                EventId = 1,
                Severity = Level.Description,
                Priority = 9 - Level.Value
            };

            return Log(entry);
        }


        public int Info(string message, IMetadata data, [CallerMemberName] string caller = null)
        {
            LogEntry entry = new LogEntry()
            {
                Level = LogLevels.Info,
                Message = message,
                Detail = JsonConvert.SerializeObject(data),
                Timestamp = DateTime.Now,
                Caller = caller,
                AppName = "Publix.Risk.IncidentIntake",
                MachineName = Environment.MachineName,
                EventId = 0,
                Severity = Level.Description,
                Priority = 9 - Level.Value
            };

            return Log(entry);
        }


        public int Warning(string message, IMetadata data, [CallerMemberName] string caller = null)
        {
            LogEntry entry = new LogEntry()
            {
                Level = LogLevels.Warning,
                Message = message,
                Detail = JsonConvert.SerializeObject(data),
                Timestamp = DateTime.Now,
                Caller = caller,
                AppName = "Publix.Risk.IncidentIntake",
                MachineName = Environment.MachineName,
                EventId = 0,
                Severity = Level.Description,
                Priority = 9 - Level.Value
            };

            return Log(entry);
        }


        public int Log(LogEntry entry)
        {
#if !DEBUG
            pbx.Logs.Add(entry);
            return pbx.SaveChanges().Result;
#else
            return 0;
#endif
        }
    }
}
