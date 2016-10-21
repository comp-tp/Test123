#region Header

/**
 * <pre>
 *
 *  Accela Mobile
 *  File: ConfigUtil.cs
 *
 *  Accela, Inc.
 *  Copyright (C): 2011
 *
 *  Description:
 *
 *  Notes:
 * $Id: ConfigUtil.cs 142354 2011-10-21 02:19:45Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 *  2011-10-21       Jackie Yu       Init 
 * </pre>
 */

#endregion Header

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Accela.Core.Ioc;
using Accela.Core.Configurations;
using Accela.Infrastructure.Configurations;

namespace Accela.Core.Logging.Util
{
    /// <summary>
    /// ConfigUtil class for configuration information.
    /// </summary>
    public sealed class ConfigUtil
    {
        #region Private Constants

        public const string LOG_LEVEL_SETTING_NAME = "LogLevel";
        public const string LOG_STORAGE_SETTING_NAME = "Log_StorageConnectionString";
        private const TraceEventType DEFAULT_LOG_LEVEL = TraceEventType.Information;
        private const string DEBUG = "DEBUG";
        private const string INFO = "INFO";
        private const string WARN = "WARN";
        private const string ERROR = "ERROR";
        private const string CRITICAL = "CRITICAL";

        //private readonly static Func<IConfiguration> ConfigurationSettingsProvider;
        private static IConfigurationReader ConfigurationSettings { get { return ConfigurationSettingsManager.Get(); } }
        private static ISystemConfig SystemConfig { get { return IocContainer.Resolve<ISystemConfig>(); } }

        #endregion
        /// <summary>
        /// Private constructor to prevent instances.
        /// </summary>
        static ConfigUtil()
        {
        }

        /// <summary>
        /// Gets LogLevel from appSettings["LogLevel"]
        /// </summary>
        public static TraceEventType LogLevel
        {
            get
            {
                string logLevel = ConfigurationSettings.Get(LOG_LEVEL_SETTING_NAME);

                if (String.IsNullOrWhiteSpace(logLevel))
                {
                    return DEFAULT_LOG_LEVEL;
                }
                else
                {
                    TraceEventType result = DEFAULT_LOG_LEVEL;

                    logLevel = logLevel.ToUpper();

                    switch (logLevel)
                    {
                        case DEBUG:
                            result = TraceEventType.Verbose;
                            break;
                        case INFO:
                            result = TraceEventType.Information;
                            break;
                        case WARN:
                            result = TraceEventType.Warning;
                            break;
                        case ERROR:
                            result = TraceEventType.Error;
                            break;
                        case CRITICAL:
                            result = TraceEventType.Critical;
                            break;
                    }

                    return result;
                }
            }
        }

        public static string LogHost
        {
            get
            {
                try
                {
                    if (SystemConfig != null)
                    {
                        return SystemConfig.GetInstanceId();
                    }
                }
                catch
                {
                }
                return string.Empty;
            }
        }

    }
}
