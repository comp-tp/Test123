using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Storage.SQLServer
{
    public class SQLServerStorageDbConfiguration : DbConfiguration
    {
        public SQLServerStorageDbConfiguration()
        {
            this.SetExecutionStrategy("System.Data.SqlClient", () => SuspendExecutionStrategy || RetryMethod== RetryMethod.None
              ? (IDbExecutionStrategy)new DefaultExecutionStrategy()
              : new CustomDbExecutionStrategy(RetryMethod, MaxAttempts, DeltaBackoff, RetrySpans));
        }

        public static bool SuspendExecutionStrategy
        {
            get
            {
                return (bool?)CallContext.LogicalGetData("SuspendExecutionStrategy") ?? false;
            }
            set
            {
                CallContext.LogicalSetData("SuspendExecutionStrategy", value);
            }
        }

        public static RetryMethod RetryMethod
        {
            get
            {
                return (RetryMethod?)CallContext.LogicalGetData("AccelaSqlServerRetryMethod") ?? RetryMethod.Exponential;
            }
            set
            {
                CallContext.LogicalSetData("AccelaSqlServerRetryMethod", value);
            }
        }

        public static int MaxAttempts
        {
            get
            {
                return (int?)CallContext.LogicalGetData("AccelaSqlServerMaxAttempts") ?? 3;
            }
            set
            {
                CallContext.LogicalSetData("AccelaSqlServerMaxAttempts", value);
            }
        }

        public static TimeSpan DeltaBackoff
        {
            get
            {
                return (TimeSpan?)CallContext.LogicalGetData("AccelaSqlServerDeltaBackoff") ?? TimeSpan.FromSeconds(1);
            }
            set
            {
                CallContext.LogicalSetData("AccelaSqlServerDeltaBackoff", value);
            }
        }

        public static IList<TimeSpan> RetrySpans
        {
            get
            {
                return (List<TimeSpan>)CallContext.LogicalGetData("AccelaSqlServerRetrySpans");
            }
            set
            {
                CallContext.LogicalSetData("AccelaSqlServerRetrySpans", value);
            }
        }
    }
}
