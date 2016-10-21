using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Accela.Infrastructure.Storage.SQLServer
{
    public class CustomDbExecutionStrategy : IDbExecutionStrategy, IRetryPolicyConfiguration
    {
        private readonly List<Exception> _exceptionsEncountered = new List<Exception>();
        private readonly Random _random = new Random();

        private readonly int _maxAttempts;
        private readonly TimeSpan _deltaBackoff;
        private readonly RetryMethod _retryMethod;
        private readonly IList<TimeSpan> _retrySpans;

        private const int DefaultMaxRetryCount = 3;
        private const double DefaultRandomFactor = 1.1;
        private const double DefaultExponentialBase = 2;
        private static readonly TimeSpan DefaultCoefficient = TimeSpan.FromSeconds(1);
        private static readonly TimeSpan DefaultMaxDelay = TimeSpan.FromSeconds(30);

        public CustomDbExecutionStrategy()
            : this(RetryMethod.Exponential, DefaultMaxRetryCount, DefaultMaxDelay)
        {

        }

        public RetryMethod RetryMethod
        {
            get { return _retryMethod; }
        }

        public TimeSpan DeltaBackoff
        {
            get { return _deltaBackoff; }
        }

        public int MaxAttempts
        {
            get { return _maxAttempts; }
        }

        public IList<TimeSpan> RetrySpans
        {
            get { return _retrySpans; }
        }

        public CustomDbExecutionStrategy(RetryMethod retryMethod, int maxAttempts, TimeSpan deltaBackoff, IList<TimeSpan> retrySpans = null)
        {
            if (maxAttempts < 0)
            {
                throw new ArgumentOutOfRangeException("maxAttempts");
            }
            if (deltaBackoff.TotalMilliseconds < 0.0)
            {
                throw new ArgumentOutOfRangeException("deltaBackoff");
            }

            _retryMethod = retryMethod;
            _maxAttempts = maxAttempts;
            _deltaBackoff = deltaBackoff;
            _retrySpans = retrySpans;
        }

        public bool RetriesOnFailure
        {
            get { return true; }
        }

        public void Execute(Action operation)
        {
            if (operation == null)
            {
                throw new ArgumentOutOfRangeException("operation");
            }

            Execute(
                () =>
                {
                    operation();
                    return (object)null;
                });
        }

        public TResult Execute<TResult>(Func<TResult> operation)
        {
            if (operation == null)
            {
                throw new ArgumentOutOfRangeException("operation");
            }

            EnsurePreexecutionState();

            while (true)
            {
                TimeSpan? delay;

                try
                {
                    return operation();
                }
                catch (Exception ex)
                {
                    if (!UnwrapAndHandleException(ex, ShouldRetryOn))
                    {
                        throw;
                    }

                    delay = GetNextDelay(ex);
                    if (delay == null)
                    {
                        var errorMessage = String.Format("Maximum number of retries ({0}) exceeded while executing database operations with '{1}'. See inner exception for the most recent failure.", _maxAttempts, GetType().Name);
                        throw new RetryLimitExceededException(errorMessage, ex);
                    }
                }

                if (delay < TimeSpan.Zero)
                {
                    var errorMessage = String.Format("The delay '{0}' is invalid. Delay must be greater than or equal to zero.", delay);
                    throw new InvalidOperationException(errorMessage);
                }

                Thread.Sleep(delay.Value);
            }
        }

#if !NET40

        public Task ExecuteAsync(Func<Task> operation, CancellationToken cancellationToken)
        {
            if (operation == null)
            {
                throw new ArgumentOutOfRangeException("operation");
            }

            EnsurePreexecutionState();

            cancellationToken.ThrowIfCancellationRequested();

            return ProtectedExecuteAsync(
                async () =>
                {
                    await new System.Data.Entity.Utilities.TaskExtensions.CultureAwaiter(operation());
                    return true;
                }, cancellationToken);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> operation, CancellationToken cancellationToken)
        {
            if (operation == null)
            {
                throw new ArgumentOutOfRangeException("operation");
            }

            EnsurePreexecutionState();

            cancellationToken.ThrowIfCancellationRequested();

            return ProtectedExecuteAsync(operation, cancellationToken);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        private async Task<TResult> ProtectedExecuteAsync<TResult>(
            Func<Task<TResult>> operation, CancellationToken cancellationToken)
        {
            while (true)
            {
                TimeSpan? delay;

                try
                {
                    return await new System.Data.Entity.Utilities.TaskExtensions.CultureAwaiter<TResult>(operation());
                }
                catch (Exception ex)
                {
                    if (!UnwrapAndHandleException(ex, ShouldRetryOn))
                    {
                        throw;
                    }

                    delay = GetNextDelay(ex);
                    if (delay == null)
                    {
                        var errorMessage = String.Format("Maximum number of retries ({0}) exceeded while executing database operations with '{1}'. See inner exception for the most recent failure.", _maxAttempts, GetType().Name);
                        throw new RetryLimitExceededException(errorMessage, ex);
                    }
                }

                if (delay < TimeSpan.Zero)
                {
                    var errorMessage = String.Format("The delay '{0}' is invalid. Delay must be greater than or equal to zero.", delay);
                    throw new InvalidOperationException(errorMessage);
                }

                await new System.Data.Entity.Utilities.TaskExtensions.CultureAwaiter(Task.Delay(delay.Value, cancellationToken));
            }
        }

#endif

        private void EnsurePreexecutionState()
        {
            if (Transaction.Current != null)
            {
                var errorMessage = String.Format("The configured execution strategy '{0}' does not support user initiated transactions. See http://go.microsoft.com/fwlink/?LinkId=309381 for additional information.", GetType().Name);
                throw new InvalidOperationException(errorMessage);
            }

            _exceptionsEncountered.Clear();
        }

        protected internal virtual TimeSpan? GetNextDelay(Exception lastException)
        {
            TimeSpan? result = null;
            _exceptionsEncountered.Add(lastException);

            var currentRetryCount = _exceptionsEncountered.Count - 1;
            if (currentRetryCount < _maxAttempts)
            {
                switch (_retryMethod)
                {
                    case Infrastructure.RetryMethod.Discrete:
                        if (_retrySpans != null && currentRetryCount > 0 && currentRetryCount < _retrySpans.Count)
                        {
                            var retrySpansIndex = currentRetryCount > 0 ? currentRetryCount - 1 : 0;
                            // by design, not check the values which might be greater than _maxDelay
                            result = _retrySpans[retrySpansIndex];
                        }

                        break;
                    case Infrastructure.RetryMethod.Linear:
                        result = TimeSpan.FromMilliseconds(currentRetryCount * _deltaBackoff.TotalMilliseconds);

                        break;
                    case Infrastructure.RetryMethod.None:
                        break;
                    case Infrastructure.RetryMethod.Exponential:
                    default:
                        int increment = (int)((Math.Pow(2, currentRetryCount) - 1) * _random.Next((int)(_deltaBackoff.TotalMilliseconds * 0.8), (int)(_deltaBackoff.TotalMilliseconds * 1.2)));
                        int delay = (int)Math.Min(increment, _deltaBackoff.TotalMilliseconds);

                        result = TimeSpan.FromMilliseconds(delay);
                        break;
                }
            }

            return result;
        }

        public static T UnwrapAndHandleException<T>(Exception exception, Func<Exception, T> exceptionHandler)
        {
            var entityException = exception as EntityException;
            if (entityException != null)
            {
                return UnwrapAndHandleException(entityException.InnerException, exceptionHandler);
            }

            var dbUpdateException = exception as DbUpdateException;
            if (dbUpdateException != null)
            {
                return UnwrapAndHandleException(dbUpdateException.InnerException, exceptionHandler);
            }

            var updateException = exception as UpdateException;
            if (updateException != null)
            {
                return UnwrapAndHandleException(updateException.InnerException, exceptionHandler);
            }

            return exceptionHandler(exception);
        }

        protected virtual bool ShouldRetryOn(Exception exception)
        {
            bool shouldRetry = ShouldRetryOn4SqlServer(exception);

            //Logger.WriteLog("ShouldRetryOn: " + shouldRetry);
            return shouldRetry;
        }

        private static bool ShouldRetryOn4SqlServer(Exception ex)
        {
            var sqlException = ex as SqlException;
            if (sqlException != null)
            {
                // Enumerate through all errors found in the exception.
                foreach (SqlError err in sqlException.Errors)
                {
                    switch (err.Number)
                    {
                        // SQL Error Code: 41325
                        // The current transaction failed to commit due to a serializable validation failure.
                        case 41325:
                        // SQL Error Code: 41305
                        // The current transaction failed to commit due to a repeatable read validation failure.
                        case 41305:
                        // SQL Error Code: 41302
                        // The current transaction attempted to update a record that has been updated since the transaction started.
                        case 41302:
                        // SQL Error Code: 41301
                        // A previous transaction that the current transaction took a dependency on has aborted,
                        // and the current transaction can no longer commit
                        case 41301:
                        // SQL Error Code: 40613
                        // Database XXXX on server YYYY is not currently available. Please retry the connection later.
                        // If the problem persists, contact customer support, and provide them the session tracing ID of ZZZZZ.
                        case 40613:
                        // SQL Error Code: 40501
                        // The service is currently busy. Retry the request after 10 seconds. Code: (reason code to be decoded).
                        case 40501:
                        // SQL Error Code: 40197
                        // The service has encountered an error processing your request. Please try again.
                        case 40197:
                        // SQL Error Code: 10929
                        // Resource ID: %d. The %s minimum guarantee is %d, maximum limit is %d and the current usage for the database is %d.
                        // However, the server is currently too busy to support requests greater than %d for this database.
                        // For more information, see http://go.microsoft.com/fwlink/?LinkId=267637. Otherwise, please try again.
                        case 10929:
                        // SQL Error Code: 10928
                        // Resource ID: %d. The %s limit for the database is %d and has been reached. For more information,
                        // see http://go.microsoft.com/fwlink/?LinkId=267637.
                        case 10928:
                        // SQL Error Code: 10060
                        // A network-related or instance-specific error occurred while establishing a connection to SQL Server. 
                        // The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server 
                        // is configured to allow remote connections. (provider: TCP Provider, error: 0 - A connection attempt failed 
                        // because the connected party did not properly respond after a period of time, or established connection failed 
                        // because connected host has failed to respond.)"}
                        case 10060:
                        // SQL Error Code: 10054
                        // A transport-level error has occurred when sending the request to the server. 
                        // (provider: TCP Provider, error: 0 - An existing connection was forcibly closed by the remote host.)
                        case 10054:
                        // SQL Error Code: 10053
                        // A transport-level error has occurred when receiving results from the server.
                        // An established connection was aborted by the software in your host machine.
                        case 10053:
                        // SQL Error Code: 233
                        // The client was unable to establish a connection because of an error during connection initialization process before login. 
                        // Possible causes include the following: the client tried to connect to an unsupported version of SQL Server;
                        // the server was too busy to accept new connections; or there was a resource limitation (insufficient memory or maximum
                        // allowed connections) on the server. (provider: TCP Provider, error: 0 - An existing connection was forcibly closed by
                        // the remote host.)
                        case 233:
                        // SQL Error Code: 64
                        // A connection was successfully established with the server, but then an error occurred during the login process. 
                        // (provider: TCP Provider, error: 0 - The specified network name is no longer available.) 
                        case 64:
                        // DBNETLIB Error Code: 20
                        // The instance of SQL Server you attempted to connect to does not support encryption.
                        case 20:
                            return true;
                        // This exception can be thrown even if the operation completed succesfully, so it's safer to let the application fail.
                        // DBNETLIB Error Code: -2
                        // Timeout expired. The timeout period elapsed prior to completion of the operation or the server is not responding. The statement has been terminated. 
                        //case -2:
                    }
                }

                return false;
            }

            if (ex is TimeoutException)
            {
                return true;
            }

            return false;
        }
    }
}
