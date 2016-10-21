using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure
{
    public interface IRetryPolicyConfiguration
    {
        RetryMethod RetryMethod { get; }

        TimeSpan DeltaBackoff { get;}

        int MaxAttempts { get;}

        // use this will cover Linear and Exponenetial mode
        IList<TimeSpan> RetrySpans { get; }
    }

    public enum RetryMethod
    {
        None = 0,
        Discrete = 1,
        Linear = 2,
        Exponential = 3
    }
}
