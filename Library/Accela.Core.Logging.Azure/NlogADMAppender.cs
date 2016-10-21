
using Accela.Core.Logging.Azure;
using Accela.Core.Logging.Util;
using Accela.Infrastructure;
using Accela.Infrastructure.Azure.Configurations;
using Accela.Infrastructure.Azure.Queue;
using Accela.Infrastructure.Azure.Storage;
using Accela.Infrastructure.Configurations;
using Accela.Infrastructure.Queue;
using Accela.Infrastructure.Storage;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Accela.Core.Logging.NLog
{
    /// <summary>
    /// Implementation of <see cref="ILogger"/> wrapper interface.
    /// </summary>
    public class NlogADMAppender 
    {
        private string _storageConnectionString;

        #region Properties

        private IConfigurationReader ConfigurationSettings 
        { 
            get 
            { 
                return new AzureConfigurationReader(); 
            } 
        }

        private IQueueStorage<LogEntity> QueueStorage 
        {
            get 
            {
                return new AzureQueueStorage<LogEntity>(new StorageConnectionStringSetting(_storageConnectionString), null); 
            } 
        }

        private AzureBinaryStorage BinaryStorage
        {
            get
            {
                return new AzureBinaryStorage(new StorageConnectionStringSetting(_storageConnectionString), null);
            }
        }

        /// <summary>
        /// Gets the name of the logger.
        /// </summary>
        public string Name 
        {
            get
            {
                return "ADM Logger";
            }  
        }

        

        #endregion Properties
        public NlogADMAppender(string storageConnectionString)
        {
            if(String.IsNullOrWhiteSpace(storageConnectionString))
            {
                throw new ArgumentNullException("storageConnectionString");
            }

            _storageConnectionString = storageConnectionString;
        }


        #region Methods


        public void WriteLog(string logLevel, ILogEntity log)
        {
            WriteLog(logLevel, log.Message, log.TraceId, log.Order, log.UserName, log.Agency, log.AppId, log.EnvName, log.Detail, log.MethodName, log.MethodExecuteTime, log.MethodInSize, log.MethodOutSize, log.RequestFrom, log.RequestTo);
        }


        private void WriteLog(string logLevel, string message, string traceId, int order, string userName, string agency, string app, string envName, string detail = null, string methodName = null, int methodExecuteTime = 0, int methodInDataSize = 0, int methodOutDataSize = 0, string requestFrom = null, string requestTo = null, string requestToServer = null)
        {
            if (String.IsNullOrEmpty(requestFrom))
            {
                requestFrom = ConfigurationSettings.Get("current_sub_system");
            }

            if (String.IsNullOrEmpty(requestTo))
            {
                requestTo = ConfigurationSettings.Get("current_sub_system");
            }

            Task.Factory.StartNew(() =>
            {
                try
                {
                    var logEntry = new LogADMEntity();
                    logEntry.TraceId = StringHelper.SubString(traceId, 100);    //100
                    logEntry.Order = order;
                    logEntry.LogLevel = StringHelper.SubString(logLevel, 20);  //20
                    logEntry.Message = StringHelper.SubString(message, 250); // max length of message is 250
                    logEntry.MethodName = StringHelper.SubString(methodName, 250); //250
                    logEntry.MethodExecuteTime = methodExecuteTime;
                    logEntry.UserName = StringHelper.SubString(userName, 100);  //100
                    logEntry.Agency = StringHelper.SubString(agency, 60);      //60
                    logEntry.EnvName = envName;
                    logEntry.AppId = StringHelper.SubString(app, 100);        //100
                    logEntry.RequestFrom = StringHelper.SubString(requestFrom, 100);
                    logEntry.RequestTo = StringHelper.SubString(requestTo, 100);
                    logEntry.DateCreated = DateTime.UtcNow;

                    var DetailBlobSize = String.IsNullOrEmpty(detail) ? 0 : detail.Length;

                    logEntry.Detail = detail;

                    if (DetailBlobSize > 2000)
                    {
                        // write detail into logs blob storage                 
                        string blobContainer = String.Format("logs-{0}", DateTime.UtcNow.ToString("yyyyMMdd")).ToLower();
                        string blobName = String.Format("{0}/{1}/{2}", logLevel, traceId, Guid.NewGuid().ToString().Substring(0, 8));
                        BinaryStorage.CreateNewOrUpdate(blobContainer, blobName, logEntry.Detail);
                        logEntry.DetailBlobUri = String.Format("{0}{1}/{2}", BinaryStorage.StorageUri , blobContainer, blobName);
                    }

                    AddToQueue(logEntry);
                }
                catch(Exception ex)
                {
                }
            });
        }



        /// <summary>
        /// write log to azure queues, then worker role will batch insert logs to db
        /// </summary>
        /// <param name="logEntry"></param>
        private void AddToQueue(LogEntity logEntry)
        {
            QueueMessage<LogEntity> message = new QueueMessage<LogEntity>(logEntry);
            message.ExpirationTime = DateTime.UtcNow.AddHours(2);
            QueueStorage.CreateNewMessage("logs", message);
        }

        /// <summary>
        /// Checks if this logger is enabled for a given <see cref="Level"/> passed as parameter.
        /// </summary>
        /// <param name="level">The level to check.</param>
        /// <returns>
        /// <c>true</c> if this logger is enabled for <c>level</c>, otherwise <c>false</c>.
        /// </returns>
        public bool IsEnabledFor(TraceEventType level)
        {
            TraceEventType configLevel = ConfigUtil.LogLevel;

            return (int)level <= (int)configLevel;
        }

        #endregion Methods
    }

    internal static class StringHelper
    {
        /// <summary>
        /// Sub string.
        /// </summary>
        /// <param name="source">source string.</param>
        /// <param name="maxLength">the max length of the string to return.</param>
        /// <returns></returns>
        public static string SubString(string source, int maxLength)
        {
            if (String.IsNullOrEmpty(source))
            {
                return source;
            }

            int length = source.Length;

            if (length <= maxLength)
            {
                return source;
            }
            else
            {
                return source.Substring(0, maxLength);
            }
        }

        public static string TryTrim(string source)
        {
            string result = null;

            if (source != null)
            {
                result = source.Trim();
            }

            return result;
        }
    }

    internal class StorageConnectionStringSetting : IConnectionStringSetting
    {
        private string _connectionString;
        public StorageConnectionStringSetting(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string Get()
        {
            return _connectionString;
        }

        public string Get(string key)
        {
            return _connectionString;
        }
    }
}
