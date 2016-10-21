using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Accela.Core.Logging.Core;
using System.Globalization;
using Accela.Core.Logging.Util;

namespace Accela.Core.Logging
{
    public class LogImpl : LoggerWrapperImpl, ILog
    {
        #region Public Instance Constructors

        /// <summary>
        /// Construct a new wrapper for the specified logger.
        /// </summary>
        /// <param name="logger">The logger to wrap.</param>
        /// <remarks>
        /// <para>
        /// Construct a new wrapper for the specified logger.
        /// </para>
        /// </remarks>
        public LogImpl(ILogger logger)
            : base(logger)
        {
        }

        #endregion Public Instance Constructors

        #region Private Static Instance Fields

        /// <summary>
        /// The fully qualified name of this declaring type not the type of any subclass.
        /// </summary>
        //private readonly static Type ThisDeclaringType = typeof(LogAzureImp);

        #endregion Private Static Instance Fields

        #region Private Fields

        private const TraceEventType _levelDebug = TraceEventType.Verbose;
        private const TraceEventType _levelInfo = TraceEventType.Information;
        private const TraceEventType _levelWarn = TraceEventType.Warning;
        private const TraceEventType _levelError = TraceEventType.Error;
        private const TraceEventType _levelCritical = TraceEventType.Critical;

        //private const string DEBUG = "Debug";
        //private const string INFO = "Info";
        //private const string WARN = "Warn";
        //private const string ERROR = "Error";
        //private const string CRITICAL = "Critical";

        #endregion

        #region Public Properties

        /// <summary>
        /// Checks if this logger is enabled for the <c>DEBUG</c>
        /// level.
        /// </summary>
        /// <value>
        /// <c>true</c> if this logger is enabled for <c>DEBUG</c> events,
        /// <c>false</c> otherwise.
        /// </value>
        virtual public bool IsDebugEnabled
        {
            get { return Logger.IsEnabledFor(_levelDebug); }
        }

        /// <summary>
        /// Checks if this logger is enabled for the <c>Information</c> level.
        /// </summary>
        /// <value>
        /// <c>true</c> if this logger is enabled for <c>Information</c> events,
        /// <c>false</c> otherwise.
        /// </value>
        virtual public bool IsInfoEnabled
        {
            get { return Logger.IsEnabledFor(_levelInfo); }
        }

        /// <summary>
        /// Checks if this logger is enabled for the <c>Warning</c> level.
        /// </summary>
        /// <value>
        /// <c>true</c> if this logger is enabled for <c>Warning</c> events,
        /// <c>false</c> otherwise.
        /// </value>
        virtual public bool IsWarnEnabled
        {
            get { return Logger.IsEnabledFor(_levelWarn); }
        }

        /// <summary>
        /// Checks if this logger is enabled for the <c>ERROR</c> level.
        /// </summary>
        /// <value>
        /// <c>true</c> if this logger is enabled for <c>ERROR</c> events,
        /// <c>false</c> otherwise.
        /// </value>
        virtual public bool IsErrorEnabled
        {
            get { return Logger.IsEnabledFor(_levelError); }
        }

        /// <summary>
        /// Checks if this logger is enabled for the <c>Critical</c> level.
        /// </summary>
        /// <value>
        /// <c>true</c> if this logger is enabled for <c>Critical</c> events,
        /// <c>false</c> otherwise.
        /// </value>
        virtual public bool IsCriticalEnabled
        {
            get { return Logger.IsEnabledFor(_levelCritical); }
        }

        #endregion

        #region Debug 
        
        public void Debug(ILogEntity log)
        {
            if (log == null)
            {
                return;
            }

            if (IsDebugEnabled)
            {
                //Logger.WriteLog("Debug", log.Message, log.Detail, log.MethodName, log.MethodExecuteTime, log.MethodInSize, log.MethodOutSize, log.RequestFrom, log.RequestTo, log.RequestToServer);
                Logger.WriteLog("Debug", log);
            }
        }

        /// <summary>
        /// Log a message with Debug level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="detail">The detail to log.</param>
        /// <param name="methodName">The method name to log for retrieve.</param>
        public void Debug(string message, string detail = null, string methodName = null, int methodExecuteTime = 0, int methodInDataSize = 0, int methodOutDataSize = 0)
        {
            if (IsDebugEnabled)
            {
                //Logger.WriteLog("Debug", message, detail, methodName, methodExecuteTime, methodInDataSize, methodOutDataSize);
                var log = new LogEntity
                {
                    Message = message,
                    Detail = detail,
                    MethodName = methodName,
                    MethodExecuteTime = methodExecuteTime,
                    MethodInSize = methodInDataSize,
                    MethodOutSize = methodOutDataSize
                };

                Logger.WriteLog("Debug", log);
            }
        }

        #endregion

        #region Info

        public void Info(ILogEntity log)
        {
            if (log == null)
            {
                return;
            }

            if (IsInfoEnabled)
            {
                //Logger.WriteLog("Info", log.Message, log.Detail, log.MethodName, log.MethodExecuteTime, log.MethodInSize, log.MethodOutSize, log.RequestFrom, log.RequestTo, log.RequestToServer);
                Logger.WriteLog("Info", log);
            }
        }

        /// <summary>
        /// Log a message with Info level.
        /// </summary>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        /// <param name="methodName">The method name to log for retrieve.</param>
        public void Info(Exception exception, string methodName = null)
        {
            if (exception == null)
            {
                return;
            }
            if (IsInfoEnabled)
            {
                //Logger.WriteLog("Info", exception.Message, GetExceptionDetail(exception), methodName);
                var log = new LogEntity
                {
                    Message = GetExceptionMessage(exception),
                    Detail = GetExceptionDetail(exception),
                    MethodName = methodName
                };

                Logger.WriteLog("Info", log);
            }
        }

        /// <summary>
        /// Log a message with Info level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="detail">The detail to log.</param>
        /// <param name="methodName">The method name to log for retrieve.</param>
        public void Info(string message, string detail = null, string methodName = null, int methodExecuteTime = 0, int methodInDataSize = 0, int methodOutDataSize = 0)
        {
            if (IsInfoEnabled)
            {
                //Logger.WriteLog("Info", message, detail, methodName, methodExecuteTime, methodInDataSize, methodOutDataSize);
                var log = new LogEntity
                {
                    Message = message,
                    Detail = detail,
                    MethodName = methodName,
                    MethodExecuteTime = methodExecuteTime,
                    MethodInSize = methodInDataSize,
                    MethodOutSize = methodOutDataSize
                };

                Logger.WriteLog("Info", log);
            }
        }

        #endregion

        #region Warn

        public void Warn(ILogEntity log)
        {
            if (log == null)
            {
                return;
            }

            if (IsWarnEnabled)
            {
                //Logger.WriteLog("Warn", log.Message, log.Detail, log.MethodName, log.MethodExecuteTime, log.MethodInSize, log.MethodOutSize, log.RequestFrom, log.RequestTo, log.RequestToServer);
                Logger.WriteLog("Warn", log);
            }
        }

        /// <summary>
        /// Log a message with Warn level.
        /// </summary>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        /// <param name="methodName">The method name to log for retrieve.</param>
        public void Warn(Exception exception, string methodName = null)
        {
            if (exception == null)
            {
                return;
            }
            if (IsWarnEnabled)
            {
                //Logger.WriteLog("Warn", exception.Message, GetExceptionDetail(exception), methodName);

                var log = new LogEntity
                {
                    Message = GetExceptionMessage(exception),
                    Detail = GetExceptionDetail(exception),
                    MethodName = methodName
                };

                Logger.WriteLog("Warn", log);
            }
        }

        /// <summary>
        /// Log a message with Warn level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="detail">The detail to log.</param>
        /// <param name="methodName">The method name to log for retrieve.</param>
        public void Warn(string message, string detail = null, string methodName = null)
        {
            if (IsWarnEnabled)
            {
                //Logger.WriteLog("Warn", message, detail, methodName, methodExecuteTime, methodInDataSize, methodOutDataSize);
                var log = new LogEntity
                {
                    Message = message,
                    Detail = detail,
                    MethodName = methodName
                };

                Logger.WriteLog("Warn", log);
            }
        }

        #endregion

        #region Error

        public void Error(ILogEntity log)
        {
            if (log == null)
            {
                return;
            }

            if (IsErrorEnabled)
            {
                //Logger.WriteLog("Error", log.Message, log.Detail, log.MethodName, log.MethodExecuteTime, log.MethodInSize, log.MethodOutSize, log.RequestFrom, log.RequestTo, log.RequestToServer);
                Logger.WriteLog("Error", log);
            }
        }

        /// <summary>
        /// Log a message with Error level.
        /// </summary>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        /// <param name="methodName">The method name to log for retrieve.</param>
        public void Error(Exception exception, string methodName = null)
        {
            if (exception == null)
            {
                return;
            }
            if (IsErrorEnabled)
            {
                //Logger.WriteLog("Error", exception.Message, GetExceptionDetail(exception), methodName);

                var log = new LogEntity
                {
                    Message = GetExceptionMessage(exception),
                    Detail = GetExceptionDetail(exception),
                    MethodName = methodName
                };

                Logger.WriteLog("Error", log);
            }
        }

        /// <summary>
        /// Log a message with Error level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="detail">The detail to log.</param>
        /// <param name="methodName">The method name to log for retrieve.</param>
        public void Error(string message, string detail = null, string methodName = null)
        {
            if (IsErrorEnabled)
            {
                //Logger.WriteLog("Error", message, detail, methodName, methodExecuteTime, methodInDataSize, methodOutDataSize);
                var log = new LogEntity
                {
                    Message = message,
                    Detail = detail,
                    MethodName = methodName
                };

                Logger.WriteLog("Error", log);
            }
        }

        #endregion

        #region Critical

        public void Critical(ILogEntity log)
        {
            if (log == null)
            {
                return;
            }

            if (IsCriticalEnabled)
            {
                //Logger.WriteLog("Critical", log.Message, log.Detail, log.MethodName, log.MethodExecuteTime, log.MethodInSize, log.MethodOutSize, log.RequestFrom, log.RequestTo, log.RequestToServer);
                Logger.WriteLog("Critical", log);
            }
        }

        /// <summary>
        /// Log a message with Critical level.
        /// </summary>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        /// <param name="methodName">The method name to log for retrieve.</param>
        public void Critical(Exception exception, string methodName = null)
        {
            if (exception == null)
            {
                return;
            }
            if (IsCriticalEnabled)
            {
                //Logger.WriteLog("Critical", exception.Message, GetExceptionDetail(exception), methodName);
                var log = new LogEntity
                {
                    Message = GetExceptionMessage(exception),
                    Detail = GetExceptionDetail(exception),
                    MethodName = methodName
                };

                Logger.WriteLog("Critical", log);
            }
        }

        /// <summary>
        /// Log a message with Critical level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="detail">The detail to log.</param>
        /// <param name="methodName">The method name to log for retrieve.</param>
        public void Critical(string message, string detail = null, string methodName = null)
        {
            if (IsCriticalEnabled)
            {
                var log = new LogEntity
                {
                    Message = message,
                    Detail = detail,
                    MethodName = methodName
                };

                Logger.WriteLog("Critical", log);
            }
        }

        #endregion

        private string GetExceptionDetail(Exception ex)
        {
            if (ex == null)
            {
                return String.Empty;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(ex.Message);
            sb.AppendLine();
            sb.Append(ex.StackTrace);
            if (ex is AggregateException)
            {
                ((AggregateException)ex).Flatten().Handle((innerException) =>
                {
                    while (innerException != null)
                    {
                        sb.AppendLine();
                        sb.Append("* ");
                        sb.AppendLine(innerException.Message);
                        sb.AppendLine(innerException.StackTrace);
                        innerException = innerException.InnerException;
                    }

                    return true;
                });
            }

            return sb.ToString();
        }

        private string GetExceptionMessage(Exception ex)
        {
            if (ex == null)
            {
                return String.Empty;
            }

            try
            {
                if (ex is AggregateException)
                {
                    AggregateException ae = ex as AggregateException;
                    StringBuilder sbExceptions = new StringBuilder();
                    string split = " -->";
                    int i = 0;
                    foreach (var innerEx in ae.InnerExceptions)
                    {
                        if (i == 1)
                        {
                            sbExceptions.Append(" (");
                        }

                        if (i > 1)
                        {
                            sbExceptions.Append(split);
                        }

                        sbExceptions.Append(innerEx.Message);

                        i++;
                    }

                    if (i > 1)
                    {
                        sbExceptions.Append(")");
                    }

                    return sbExceptions.ToString();
                }
                else
                {
                    return ex.Message;
                }
            }
            catch { }

            return String.Empty;
        }
    }
}
