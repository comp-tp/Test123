#region Header

/**
 * <pre>
 *
 *  Accela Mobile
 *  File: ILog.cs
 *
 *  Accela, Inc.
 *  Copyright (C): 2011
 *
 *  Description:
 *
 *  Notes:
 * $Id: ILog.cs 142354 2011-10-21 02:19:45Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 *  2011-10-21       Jackie Yu       Init 
 * </pre>
 */

#endregion

using System;
using System.Reflection;
using Accela.Core.Logging.Core;
using System.Diagnostics;

namespace Accela.Core.Logging
{
	/// <summary>
	/// The ILog interface is use by application to log messages into repository.
	/// </summary>
	public interface ILog
	{
        
        void Debug(ILogEntity log);

        /// <summary>
        /// Log a message with Debug level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="detail">The detail to log.</param>
        /// <param name="methodName">The method name to log for retrieve.</param>
        void Debug(string message, string detail = null, string methodName = null, int methodExecuteTime = 0, int methodInDataSize = 0, int methodOutDataSize = 0);

        void Info(ILogEntity log);

        /// <summary>
        /// Log a message with Info level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="detail">The detail to log.</param>
        /// <param name="methodName">The method name to log for retrieve.</param>
        void Info(string message, string detail = null, string methodName = null, int methodExecuteTime = 0, int methodInDataSize = 0, int methodOutDataSize = 0);

        void Warn(ILogEntity log);

        /// <summary>
        /// Log a message with Warn level.
        /// </summary>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        /// <param name="methodName">The method name to log for retrieve.</param>
        void Warn(Exception exception, string methodName = null);

        /// <summary>
        /// Log a message with Warn level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="detail">The detail to log.</param>
        /// <param name="methodName">The method name to log for retrieve.</param>
        void Warn(string message, string detail = null, string methodName = null);

        void Error(ILogEntity log);

        /// <summary>
        /// Log a message with Error level.
        /// </summary>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        /// <param name="methodName">The method name to log for retrieve.</param>
        void Error(Exception exception, string methodName = null);

        /// <summary>
        /// Log a message with Error level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="detail">The detail to log.</param>
        /// <param name="methodName">The method name to log for retrieve.</param>
        void Error(string message, string detail = null, string methodName = null);

        void Critical(ILogEntity log);
        /// <summary>
        /// Log a message with Critical level.
        /// </summary>
        /// <param name="exception">The exception to log, including its stack trace.</param>
        /// <param name="methodName">The method name to log for retrieve.</param>
        void Critical(Exception exception, string methodName = null);

        /// <summary>
        /// Log a message with Critical level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="detail">The detail to log.</param>
        /// <param name="methodName">The method name to log for retrieve.</param>
        void Critical(string message, string detail = null, string methodName = null);

		/// <summary>
		/// Checks if this logger is enabled for the <see cref="TraceEventType.Debug"/> TraceEventType.
		/// </summary>
		/// <value>
		/// <c>true</c> if this logger is enabled for <see cref="TraceEventType.Debug"/> events, <c>false</c> otherwise.
		/// </value>
		bool IsDebugEnabled { get; }
  
		/// <summary>
		/// Checks if this logger is enabled for the <see cref="TraceEventType.Information"/> TraceEventType.
		/// </summary>
		/// <value>
		/// <c>true</c> if this logger is enabled for <see cref="TraceEventType.Information"/> events, <c>false</c> otherwise.
		/// </value>
		bool IsInfoEnabled { get; }

		/// <summary>
        /// Checks if this logger is enabled for the <see cref="TraceEventType.Warning"/> TraceEventType.
		/// </summary>
		/// <value>
		/// <c>true</c> if this logger is enabled for <see cref="TraceEventType.Warning"/> events, <c>false</c> otherwise.
		/// </value>
		bool IsWarnEnabled { get; }

		/// <summary>
		/// Checks if this logger is enabled for the <see cref="TraceEventType.Error"/> TraceEventType.
		/// </summary>
		/// <value>
		/// <c>true</c> if this logger is enabled for <see cref="TraceEventType.Error"/> events, <c>false</c> otherwise.
		/// </value>
		bool IsErrorEnabled { get; }

		/// <summary>
		/// Checks if this logger is enabled for the <see cref="TraceEventType.Critical"/> TraceEventType.
		/// </summary>
		/// <value>
		/// <c>true</c> if this logger is enabled for <see cref="TraceEventType.Critical"/> events, <c>false</c> otherwise.
		/// </value>
		bool IsCriticalEnabled { get; }
	}
}
