using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Core.Utilities
{
    public class Guard
    {
        /// <summary>
        /// Throws TException if predicate is not true.
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="parameterName"></param>
        public static void Requires<TException>(bool predicate, string parameterName)
            where TException : Exception, new()
        {
            if (!predicate)
            {
                //Debug.WriteLine(Message);
                throw (TException)Activator.CreateInstance(typeof(TException), parameterName);
            }
        }


        /// <summary>
        /// Throws TException if predicate is not true.
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="parameterName"></param>
        /// <param name="message"></param>
        public static void Requires<TException>(bool predicate, string parameterName, string message)
            where TException : Exception, new()
        {
            if (!predicate)
            {
                //Debug.WriteLine(Message);
                throw (TException)Activator.CreateInstance(typeof(TException), parameterName, message);
            }
        }


        /// <summary>
        /// Throws TException if predicate returns true.
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="parameterName"></param>
        public static void ThrowIf<TException>(bool predicate, string parameterName)
            where TException : Exception, new()
        {
            if (predicate)
            {
                //Debug.WriteLine(Message);
                throw (TException)Activator.CreateInstance(typeof(TException), parameterName);
            }
        }

        /// <summary>
        /// Throws TException if predicate returns true.
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="parameterName"></param>
        /// <param name="message"></param>
        public static void ThrowIf<TException>(bool predicate, string parameterName, string message)
           where TException : Exception, new()
        {
            if (predicate)
            {
                //Debug.WriteLine(Message);
                throw (TException)Activator.CreateInstance(typeof(TException), parameterName, message);
            }
        }
    }  
}
