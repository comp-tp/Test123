#region Header

/**
 * <pre>
 *
 *  Accela Mobile
 *  File: ILogger.cs
 *
 *  Accela, Inc.
 *  Copyright (C): 2011
 *
 *  Description:
 *
 *  Notes:
 * $Id: ILogger.cs 142354 2011-10-21 02:19:45Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 *  2011-10-21       Jackie Yu       Init 
 * </pre>
 */

#endregion Header

using System;
using System.Diagnostics;

namespace Accela.Core.Logging
{
    /// <summary>
    /// Interface that all loggers implement
    /// </summary>


    public interface ILogger
    {
        /// <summary>
        /// Gets the name of the logger.
        /// </summary>
        string Name { get; }

        ///// <summary>
        ///// This generic form is intended to be used by wrappers.
        ///// </summary>
        ///// <param name="callerStackBoundaryDeclaringType">The declaring type of the method that is
        ///// the stack boundary into the logging system for this call.</param>
        ///// <param name="severity">The severity/level of the message to be logged.</param>
        ///// <param name="message">The message object to log.</param>
        ///// <param name="exception">the exception to log, including its stack trace. Pass <c>null</c> to not log an exception.</param>
        ///// <param name="traceID">trace ID.</param>
        //void Log(Type callerStackBoundaryDeclaringType, TraceEventType severity, object message, Exception exception, string traceID = "");

        /// <summary>
        /// Log a message with the <see cref="TraceEventType"/> level.
        /// </summary>
        /// <param name="logLevel">Identifies the type of event that has caused the trace.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="detail">The detail to log.</param>
        /// <param name="methodName">The method name to log for retrieve.</param>
        /// <param name="methodDuration">The method excute duration time.</param>
        //void WriteLog(string logLevel, string message, string detail, string traceId = null, int order = 1, string methodName = null, int methodExecuteTime = 0, int methodInDataSize = 0, int methodOutDataSize = 0, string appId = null, string appVersion = null, string envName = null, string userName = null, string agency = null, string requestFrom = null, string requestTo = null);

        void WriteLog(string logLevel, ILogEntity log);

        /// <summary>
        /// Checks if this logger is enabled for a given <see cref="Level"/> passed as parameter.
        /// </summary>
        /// <param name="level">The level to check.</param>
        /// <returns>
        /// <c>true</c> if this logger is enabled for <c>level</c>, otherwise <c>false</c>.
        /// </returns>
        bool IsEnabledFor(TraceEventType level);
    }
}
