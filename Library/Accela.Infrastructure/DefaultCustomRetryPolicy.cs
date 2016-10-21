using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure
{
    public class CustomRetryPolicyConfiguration : IRetryPolicyConfiguration
    {
        private const int DEFAULT_MAX_ATTEMPTS = 3;
        //private static WebExceptionStatus[] transientExceptions = new[] {
        //            WebExceptionStatus.ConnectionClosed, 
        //            WebExceptionStatus.Timeout, 
        //            WebExceptionStatus.RequestCanceled
        //        };

        //public virtual bool IsTransient(Exception ex)
        //{
        //    // Determine if the exception is transient.
        //    // In some cases this may be as simple as checking the exception type, in other 
        //    // cases it may be necessary to inspect other properties of the exception.
        //    //if (ex is OperationTransientException)
        //    //    return true;

        //    var webException = ex as WebException;
        //    if (webException != null)
        //    {
        //        // If the web exception contains one of the following status values 
        //        // it may be transient.
        //        return transientExceptions.Contains(webException.Status);
        //    }

        //    // Additional exception checking logic goes here.
        //    return false;
        //}

        private RetryMethod _retryMetod = RetryMethod.Exponential;

        public virtual RetryMethod RetryMethod
        {
            get
            {
                return _retryMetod;
            }
            set
            {
                _retryMetod = value;
            }
        }

        private TimeSpan _deltaBackoff = TimeSpan.FromMilliseconds(500);
        public virtual TimeSpan DeltaBackoff
        {
            get
            {
                return _deltaBackoff;
            }
            set
            {
                _deltaBackoff = value;
            }
        }

        private int _maxAttempts = 3;
        public virtual int MaxAttempts
        {
            get 
            {
                return _maxAttempts; 
            }
            set
            {
                if(value < 0 )
                {
                    throw new ArgumentOutOfRangeException("Negative number is not allowed.");
                }
                _maxAttempts = value;
            }
        }

        public IList<TimeSpan> RetrySpans
        {
            get;
            set;
        }
    }
}
