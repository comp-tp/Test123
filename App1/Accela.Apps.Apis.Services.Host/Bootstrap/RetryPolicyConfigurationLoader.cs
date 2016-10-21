using Accela.Apps.Shared.Exceptions;
using Accela.Infrastructure;
using Accela.Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.Apis.Ioc
{
    public class RetryPolicyConfigurationLoader : CustomRetryPolicyConfiguration
    {
        IConfigurationReader _reader = null;
        public RetryPolicyConfigurationLoader(IConfigurationReader configurationReader) : base()
        {
            if (configurationReader == null)
            {
                throw new ArgumentNullException("configurationReader is null");
            }

            _reader = configurationReader;

            string policyString = _reader.Get("StorageRetryPolicy");

            if (string.IsNullOrWhiteSpace(policyString))
            {
                throw new MobileException("StorageRetryPolicy is not configured.");
            }

            // configuration sample
            //RetryMethod:Exponential,DeltaBackOffMilliSeconds:500,MaxAttempts:3
            //RetryMethod: one of below values :None, Linear , Exponential}

            // Must have above 3 settings
            var array1 = policyString.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (array1.Length != 3)
            {
                throw new MobileException("StorageRetryPolicy is not configured properly.");
            }

            foreach (var kv in array1)
            {
                var array2 = kv.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                if (array2.Length != 2)
                {
                    throw new MobileException("StorageRetryPolicy is not configured properly.");
                }
                else
                {
                    bool keyExists = false;
                    if (array2[0].Equals("RetryMethod", StringComparison.OrdinalIgnoreCase))
                    {
                        keyExists = true;
                        RetryMethod retryMethodResult;

                        var success = RetryMethod.TryParse<RetryMethod>(array2[1], out retryMethodResult);

                        if (success)
                        {
                            base.RetryMethod = retryMethodResult;
                        }
                        else
                        {
                            throw new MobileException("StorageRetryPolicy is not configured properly, RetryMethod must be of values : None, Linear, Exponential.");
                        }
                    }
                    else if (array2[0].Equals("DeltaBackOffMilliSeconds", StringComparison.OrdinalIgnoreCase))
                    {
                        keyExists = true;
                        int deltBackoffResult;

                        var success = Int32.TryParse(array2[1], out deltBackoffResult);

                        if (success && deltBackoffResult > 0)
                        {
                            base.DeltaBackoff = TimeSpan.FromMilliseconds(deltBackoffResult);
                        }
                        else
                        {
                            throw new MobileException("StorageRetryPolicy is not configured properly, DeltaBackOffMilliSeconds must be an integer.");
                        }
                    }
                    else if (array2[0].Equals("MaxAttempts", StringComparison.OrdinalIgnoreCase))
                    {
                        keyExists = true;
                        int maxAttemptsResult;

                        var success = Int32.TryParse(array2[1], out maxAttemptsResult);

                        if (success && maxAttemptsResult > 0)
                        {
                            base.MaxAttempts = maxAttemptsResult;
                        }
                        else
                        {
                            throw new MobileException("StorageRetryPolicy is not configured properly, MaxAttempts must be an integer.");
                        }
                    }

                    if (!keyExists)
                    {
                        throw new MobileException("StorageRetryPolicy is not configured properly, Invalid key : array2[0]");
                    }
                }
            }
        }
    }
}
