using Accela.Core.Logging.Util;
using NLog;
using System.Diagnostics;

namespace Accela.Core.Logging.NLog
{
    public class NLogLogger : ILogger
    {
        private static global::NLog.Logger _logger = LogManager.GetCurrentClassLogger();

        static NLogLogger()
        {
        }

        public string Name
        {
            get { return "NLog"; }
        }

        public void WriteLog(string logLevel, ILogEntity log)
        {
            if (log == null) return;

            if (string.IsNullOrEmpty(log.Host))
            {
                log.Host = ConfigUtil.LogHost;
            }

            if(!string.IsNullOrEmpty(log.Detail))
            {
                log.Detail = SensitiveDataFilter.Filter(log.Detail);
            }

            switch (logLevel.ToUpper())
            {
                case "DEBUG":
                    _logger.Debug(log.ToJson("Debug"));
                    break;
                case "INFO":
                    _logger.Info(log.ToJson("Info"));
                    break;
                case "ERROR":
                    _logger.Error(log.ToJson("Error"));
                    break;
                case "WARN":
                    _logger.Warn(log.ToJson("Warn"));
                    break;
                case "CRITICAL":
                    _logger.Fatal(log.ToJson("Critical"));
                    break;
                default:
                    _logger.Info(log.ToJson("Info"));
                    break;
            }
        }

        /// <summary>
        /// Checks if this logger is enabled for a given <see cref="Level"/> passed as parameter.
        /// </summary>
        /// <param name="level">The level to check.</param>
        /// <returns>
        /// <c>true</c> if this logger is enabled for <c>level</c>, otherwise <c>false</c>.
        /// </returns>
        public bool IsEnabledFor(TraceEventType level)
        {
            TraceEventType configLevel = ConfigUtil.LogLevel;

            return (int)level <= (int)configLevel;
        }
    }

    
   
}
