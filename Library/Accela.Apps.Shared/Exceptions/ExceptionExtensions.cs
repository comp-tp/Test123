using System;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Accela.Apps.Shared.Exceptions
{
    /// <summary>
    /// Exception Extensions
    /// </summary>
    public static class ExceptionExtensions
    {
        private const string Line = "==============================================================================";

        /// <summary>
        /// Traces the information.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        public static string TraceInformation(this Exception ex)
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

        public static T GetSpecificException<T>(this Exception ex) where T : Exception
        {
            T result = default(T);

            if (ex.GetType() == typeof(T))
            {
                result = ex as T;
                return result;
            }

            if (ex is AggregateException)
            {
                AggregateException aex = ex as AggregateException;
                foreach (var e in aex.InnerExceptions)
                {
                    if (e.GetType() == typeof(T))
                    {
                        result = e as T;
                        return result;
                    }
                    else
                    {
                        var tmp = e;
                        while (tmp.InnerException != null)
                        {
                            if (tmp.GetType() == typeof(T))
                            {
                                result = tmp as T;
                                return result;
                            }
                            else
                            {
                                tmp = tmp.InnerException;
                            }
                        }
                    }
                }
            }
            else
            {
                while (ex.InnerException != null)
                {
                    if (ex.GetType() == typeof(T))
                    {
                        result = ex as T;
                        return result;
                    }
                    else
                    {
                        ex = ex.InnerException;
                    }
                }

            }

            return result;
        }
    }
}