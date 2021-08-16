using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Publix.Risk.IncidentIntake.Domain;
using Publix.Risk.IncidentIntake.Domain.Interfaces;
using Publix.Risk.IncidentIntake.Domain.Metadata;
using Publix.Risk.IncidentIntake.Domain.ValueObjects;
using Serilog.Events;
using System;
using System.Runtime.CompilerServices;

namespace Publix.Risk.IncidentIntake.Persistence
{
    public class DbLogger : Serilog.ILogger, ILogger, IDisposable
    {
        private IPBXContext pbx { get; }


        public DbLogger(IPBXContext context, IConfiguration config)
        {
            Level = LogLevels.FromDescription(config["LogLevel"]) ?? LogLevels.Info;
            pbx = context;
        }


        public LogLevels Level { get; }


        public int LogDebug(string message, IMetadata data, [CallerMemberName] string caller = null)
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


        public int LogError(string message, IMetadata data, [CallerMemberName] string caller = null)
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


        public int LogError(Exception ex, IMetadata data, [CallerMemberName] string caller = null)
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


        public int LogInfo(string message, IMetadata data, [CallerMemberName] string caller = null)
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


        public int LogWarning(string message, IMetadata data, [CallerMemberName] string caller = null)
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

        public bool IsEnabled(LogEventLevel logLevel)
        {
            int level = (int)logLevel;
            if (level == 0)
            {
                level = LogLevels.Verbose.Value;
            }

            LogLevels newLevel = LogLevels.FromValue(level) ?? LogLevels.Info;

            return LogLevels.ShouldLog(Level, newLevel);
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return this;
        }

        public void Dispose()
        {
            pbx.SaveChanges();
        }

        public void Write(LogEvent logEvent)
        {
            if (IsEnabled(logEvent.Level))
            {
                switch (logEvent.Level)
                {
                    case LogEventLevel.Verbose:
                    case LogEventLevel.Fatal:
                    case LogEventLevel.Error:
                        LogError(logEvent.Exception, new OtherMetadata(logEvent.Properties));
                        break;

                    case LogEventLevel.Debug:
                        LogDebug(logEvent.MessageTemplate.ToString(), new OtherMetadata(logEvent.Properties));
                        break;

                    case LogEventLevel.Information:
                        LogInfo(logEvent.MessageTemplate.ToString(), new OtherMetadata(logEvent.Properties));
                        break;

                    case LogEventLevel.Warning:
                        LogWarning(logEvent.MessageTemplate.ToString(), new OtherMetadata(logEvent.Properties));
                        break;

                    default:
                        //do nothing
                        break;
                }
            }
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (IsEnabled(logLevel))
            {
                switch (logLevel)
                {
                    case LogLevel.Critical:
                    case LogLevel.Error:
                        LogError(exception, new OtherMetadata(state));
                        break;

                    case LogLevel.Debug:
                        LogDebug(formatter(state, exception), new OtherMetadata(state));
                        break;

                    case LogLevel.Information:
                        LogInfo(formatter(state, exception), new OtherMetadata(state));
                        break;

                    case LogLevel.Warning:
                        LogWarning(formatter(state, exception), new OtherMetadata(state));
                        break;

                    default:
                        //do nothing
                        break;
                }
            }
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return LogLevels.ShouldLog(Level, LogLevels.FromValue((int)logLevel) ?? LogLevels.Info);
        }
    }
}
