using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Core.Logging
{
    public sealed class LogUtil
    {
        /// <summary>
        /// Generate a new trace id.
        /// </summary>
        /// <returns>trace id.</returns>
        public static string NewTraceID()
        {
            return String.Format("{0}-{1}", DateTime.UtcNow.ToString("yyMMddHHmmssfff"), Guid.NewGuid().ToString().Substring(0, 8).ToLower());
        }
    }
}
