using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Core.Logging.Util
{
    public static class LogJsonHelper
    {
        public static string ToJson(this ILogEntity log, string logLevel)
        {
            // Sample data
            //{
            //  "TraceId": null,
            //  "Message": "Hello",
            //  "Detail": "The detail data here",
            //  "MethodName": null,
            //  "MethodExecuteTime": 0,
            //  "UserName": null,
            //  "Agency": "UTTestAgency",
            //  "EnvName": null,
            //  "AppId": "UTAppId123",
            //  "RequestFrom": null,
            //  "RequestTo": null,
            //  "DetailSize": 0
            //}

            StringBuilder sbResult = new StringBuilder("{");
            sbResult.AppendFormat("\"LogLevel\":\"{0}\"", logLevel);

            if (!String.IsNullOrWhiteSpace(log.TraceId))
            {
                sbResult.AppendFormat(",\"TraceId\":\"{0}\"", log.TraceId);
            }

            if (!String.IsNullOrWhiteSpace(log.Host))
            {
                sbResult.AppendFormat(",\"Host\":\"{0}\"", EscapeString(log.Host));
            }

            if (!String.IsNullOrWhiteSpace(log.Message))
            {
                sbResult.AppendFormat(",\"Message\":\"{0}\"", EscapeString(log.Message));
            }

            if (!String.IsNullOrWhiteSpace(log.MethodName))
            {
                sbResult.AppendFormat(",\"MethodName\":\"{0}\"", EscapeString(log.MethodName));
            }

            if (log.MethodExecuteTime > 0)
            {
                sbResult.AppendFormat(",\"MethodExecuteTime\":{0}", log.MethodExecuteTime);
            }

            if (!String.IsNullOrWhiteSpace(log.Agency))
            {
                sbResult.AppendFormat(",\"Agency\":\"{0}\"", EscapeString(log.Agency));
            }

            if (!String.IsNullOrWhiteSpace(log.UserName))
            {
                sbResult.AppendFormat(",\"User\":\"{0}\"", EscapeString(log.UserName));
            }

            if (!String.IsNullOrWhiteSpace(log.EnvName))
            {
                sbResult.AppendFormat(",\"Env\":\"{0}\"", log.EnvName);
            }

            if (!String.IsNullOrWhiteSpace(log.AppId))
            {
                sbResult.AppendFormat(",\"App\":\"{0}\"", log.AppId);
            }

            if (!String.IsNullOrWhiteSpace(log.ClientIP))
            {
                sbResult.AppendFormat(",\"ClientIP\":\"{0}\"", log.ClientIP);
            }

            if (!String.IsNullOrWhiteSpace(log.Detail))
            {
                sbResult.AppendFormat(",\"DetailLength\":{0}", log.Detail.Length);
                sbResult.AppendFormat(",\"Detail\":\"{0}\"", EscapeString(log.Detail));
            }

            if (!String.IsNullOrWhiteSpace(log.RequestFrom))
            {
                sbResult.AppendFormat(",\"RequestFrom\":\"{0}\"", EscapeString(log.RequestFrom));
            }

            if (!String.IsNullOrWhiteSpace(log.RequestTo))
            {
                sbResult.AppendFormat(",\"RequestTo\":\"{0}\"", EscapeString(log.RequestTo));
            }

            sbResult.Append("}");
            return sbResult.ToString();
        }

        private static string EscapeString(string s, bool useEscapedUnicode = false)
        {
            var output = new StringBuilder();

            int runIndex = -1;
            int l = s.Length;
            for (var index = 0; index < l; ++index)
            {
                var c = s[index];

                if (useEscapedUnicode)
                {
                    if (c >= ' ' && c < 128 && c != '\"' && c != '\\')
                    {
                        if (runIndex == -1)
                            runIndex = index;

                        continue;
                    }
                }
                else
                {
                    if (c != '\t' && c != '\n' && c != '\r' && c != '\"' && c != '\\')// && c != ':' && c!=',')
                    {
                        if (runIndex == -1)
                            runIndex = index;

                        continue;
                    }
                }

                if (runIndex != -1)
                {
                    output.Append(s, runIndex, index - runIndex);
                    runIndex = -1;
                }

                switch (c)
                {
                    case '\t': output.Append("\\t"); break;
                    case '\r': output.Append("\\r"); break;
                    case '\n': output.Append("\\n"); break;
                    case '"':
                    case '\\': output.Append('\\'); output.Append(c); break;
                    default:
                        if (useEscapedUnicode)
                        {
                            output.Append("\\u");
                            output.Append(((int)c).ToString("X4", NumberFormatInfo.InvariantInfo));
                        }
                        else
                            output.Append(c);

                        break;
                }
            }

            if (runIndex != -1)
                output.Append(s, runIndex, s.Length - runIndex);

            return output.ToString();
        }
    }
}
