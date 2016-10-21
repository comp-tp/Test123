using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure
{
    public class NoRetryPolicyConfiguration : IRetryPolicyConfiguration
    {
        public RetryMethod RetryMethod
        {
            get { return RetryMethod.None; }
        }

        public TimeSpan DeltaBackoff
        {
            get { return TimeSpan.FromMilliseconds(0); }
        }

        public int MaxAttempts
        {
            get { return 0; }
        }


        public IList<TimeSpan> RetrySpans
        {
            get { return null; }
        }
    }
}
