using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Accela.Core.Logging;
using System.Runtime.Remoting.Messaging;
using Accela.Apps.Shared.Contexts;

namespace Accela.Apps.Shared.Utils
{
    public sealed class LogHelper
    {
        /// <summary>
        /// Generate a new Trace Id.
        /// </summary>
        /// <returns>trace id.</returns>
        public static string NewTraceID()
        {
            return LogUtil.NewTraceID();
        }

        public static string NewTraceIdIfNotExistsInContext()
        {
            string traceId = null;

            var context = CallContext.LogicalGetData("ContextEntity") as IAgencyAppContext;

            if (context != null && !string.IsNullOrWhiteSpace(context.TraceID))
            {
                traceId = context.TraceID;
            }

            if (traceId == null)
            {
                traceId = LogUtil.NewTraceID();
            }

            return traceId;
        }

        /// <summary>
        /// get current file path and method name
        /// </summary>
        /// <returns>file path & method name</returns>
        public static string GetCurrentMethodName()
        {
            StackTrace st = new StackTrace(true);
            string methodName = st.GetFrame(2).GetFileName() + ":" + st.GetFrame(2).GetMethod().Name.ToString();

            return methodName;
        }
    }
}
