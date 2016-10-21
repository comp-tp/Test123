

using Accela.Core.Logging.NLog;
/**
* <pre>
*
*  Accela Mobile
*  File: LogFactory.cs
*
*  Accela, Inc.
*  Copyright (C): 2011
*
*  Description:
*
*  Notes:
* $Id: LogFactory.cs 142354 2011-10-21 02:19:45Z ACHIEVO\jackie.yu $.
*  Revision History
*  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
*  2011-10-21       Jackie Yu       Init 
* </pre>
*/
namespace Accela.Core.Logging
{
    /// <summary>
    /// TODO: the design pattern of the log factory is messy; it provides both static and non-static method
    /// From static calls instance; from instance method calls static instance
    /// Suggest 
    /// uniform log interface for custom code
    /// </summary>
    public sealed class LogFactory : ILogFactory
    {
        #region Fields

        /// <summary>
        /// ILog instance
        /// </summary>
        private static ILog _concreteLog;

        /// <summary>
        /// This field is used to lock a object
        /// </summary>
        private static object[] _lock = new object[] { };

        /// <summary>
        /// LogFactory singleton instance
        /// </summary>
        private static LogFactory _logFactoryInstance;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Prevents a default instance of the LoggerFactory class from being created.
        /// </summary>
        public LogFactory()
        {

        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets LogFactory instance using singleton.
        /// </summary>
        /// <returns>Returns LogFactory instance.</returns>
        private static LogFactory Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_logFactoryInstance == null)
                    {
                        _logFactoryInstance = new LogFactory();
                    }
                }

                return _logFactoryInstance;
            }
        }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Gets a default ILog instance
        /// </summary>
        /// <returns></returns>
        public static ILog GetLog()
        {
            // TODO: IoC
            return LogFactory.Instance.CreateLog(new NLogLogger(), false);
        }

        /// <summary>
        /// Gets a ILog instance using a specified Logger repository.
        /// </summary>
        /// <returns></returns>
        public static ILog GetLog(ILogger logger, bool overrideLogger = false)
        {
            return LogFactory.Instance.CreateLog(logger, overrideLogger);
        }

        /// <summary>
        /// Gets a Logger using default Logger repository.
        /// </summary>
        /// <returns></returns>
        private ILog CreateLog(ILogger logger, bool overrideLogger)
        {
            if (overrideLogger || _concreteLog == null)
            {
                //ILogger logger = new AzureLogger();
                _concreteLog = new LogImpl(logger);
            }

            return _concreteLog;
        }

        #endregion Public Methods


        ILog ILogFactory.GetLog()
        {
            return LogFactory.Instance.CreateLog(new NLogLogger(), false);
        }
    }
}