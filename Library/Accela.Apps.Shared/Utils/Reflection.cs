using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;

namespace Accela.Apps.Shared
{
    public static class Reflection
    {
        /// <summary>
        /// Get current method full name with namespace.
        /// </summary>
        public static string CurrentMethodName
        {
            get
            {
                string result = "";
                try
                {
                    StackTrace stackTrace = new StackTrace(true);
                    MethodBase methodBase = stackTrace.GetFrame(1).GetMethod();

                    result = String.Format("{0}.{1}", methodBase.DeclaringType.FullName, methodBase.Name);
                }
                catch
                {
                    result = "Reflection.CurrentMethodName";
                }

                return result;
            }
        }

        /// <summary>
        /// Initializes a new System.Diagnostics.Stopwatch instance, sets the elapsed
        /// time property to zero, and starts measuring elapsed time.
        /// </summary>
        /// <returns>A new instance of Stopwatch.</returns>
        public static Stopwatch Startwatch()
        {
            Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            return watch;
        }

        /// <summary>
        /// Gets the total elapsed time measured by the current instance, in milliseconds.
        /// </summary>
        /// <param name="watch">A instance of Stopwatch.</param>
        /// <returns>the total elapsed time measured.</returns>
        public static int Stopwatch(Stopwatch watch)
        {
            int elapsedTime = 0;

            if (watch != null)
            {
                watch.Stop();
                elapsedTime = Convert.ToInt32(watch.ElapsedMilliseconds);
                watch = null;
            }

            return elapsedTime;
        }
    }
}
