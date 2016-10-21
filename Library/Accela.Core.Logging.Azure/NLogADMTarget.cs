using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Accela.Infrastructure.Azure.Configurations;
using System.Configuration;

namespace Accela.Core.Logging.NLog
{
    [Target("adm")] 
    public class NLogADMTarget : TargetWithLayout 
    {
        // azure configuration or web.config
        private const string LOG_STORAGE_SETTING_KEY = "Log_StorageConnectionString";
        public NLogADMTarget()
        {
        }

        private static string _logStorageConnenctionString = null;

        [RequiredParameter] 
        public string Host { 
            get
            {
                if(String.IsNullOrWhiteSpace(_logStorageConnenctionString))
                {
                    // 1. get value in azure cloud service configuration
                    AzureConfigurationReader azureConfigurationReader = new AzureConfigurationReader();
                    _logStorageConnenctionString = azureConfigurationReader.Get(LOG_STORAGE_SETTING_KEY);

                    // 2. No value in azure configuration, get the value from web.config
                    if (String.IsNullOrWhiteSpace(_logStorageConnenctionString))
                    {
                        _logStorageConnenctionString = ConfigurationManager.AppSettings[LOG_STORAGE_SETTING_KEY];
                    }
                }

                return _logStorageConnenctionString;
            }
            set
            {
                _logStorageConnenctionString = value;
            }
        }

        protected override void Write(LogEventInfo logEvent) 
        { 
            if(String.IsNullOrWhiteSpace(this.Host))
            {
                return;
            }

            string logMessage = this.Layout.Render(logEvent); 

            SendTheMessageToRemoteHost(this.Host, logMessage, logEvent.Level.Name ); 
        } 

        private void SendTheMessageToRemoteHost(string host, string message,string logLevel) 
        { 
            // json to object
            var logData = JsonConvert.DeserializeObject<LogEntity>(message);

            ADMLogger.WriteLog(logLevel, logData);
        }

        private static readonly object obj = new object();
        private static NlogADMAppender _ADMLogger = null;
        private NlogADMAppender ADMLogger
        {
            get
            {
                if(_ADMLogger == null)
                {
                    lock(obj)
                    {
                        if (_ADMLogger == null)
                        {
                            _ADMLogger = new NlogADMAppender(this.Host);
                        }
                    }
                }

                return _ADMLogger;
            }
        }
    }
}
