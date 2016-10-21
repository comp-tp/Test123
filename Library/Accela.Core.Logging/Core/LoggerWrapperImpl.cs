#region Header

/**
 * <pre>
 *
 *  Accela Mobile
 *  File: LoggerWrapperImpl.cs
 *
 *  Accela, Inc.
 *  Copyright (C): 2011
 *
 *  Description:
 *
 *  Notes:
 * $Id: LoggerWrapperImpl.cs 142354 2011-10-21 02:19:45Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 *  2011-10-21       Jackie Yu       Init 
 * </pre>
 */

#endregion Header

namespace Accela.Core.Logging.Core
{
	/// <summary>
	/// Abstract logic when log wrap another logger
	/// </summary>
	/// <remarks>
	/// <para>
	/// This class should be used as the base for all wrapper implementations.
	/// </para>
    /// </remarks>
	public abstract class LoggerWrapperImpl
	{
		#region Protected Instance Constructors

		/// <summary>
		/// Constructs a new wrapper for the specified logger.
		/// </summary>
		/// <param name="logger">The logger to wrap.</param>
		protected LoggerWrapperImpl(ILogger logger) 
		{
			_logger = logger;
		}

		#endregion Public Instance Constructors

		#region Implementation of ILoggerWrapper

		/// <summary>
		/// Gets the implementation behind this wrapper object.
		/// </summary>
		/// <value>
		/// The <see cref="ILogger"/> object that this object is implementing.
		/// </value>
		virtual public ILogger Logger
		{
			get { return _logger; }
		}

		#endregion

		#region Private Instance Fields

		/// <summary>
		/// The logger that this object is wrapping
		/// </summary>
		private readonly ILogger _logger;  
 
		#endregion Private Instance Fields
	}
}
