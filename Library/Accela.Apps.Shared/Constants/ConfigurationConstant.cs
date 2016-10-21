using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Accela.Apps.Shared.Contants
{
    /// <summary>
    /// configuration constant
    /// </summary>
    public static class ConfigurationConstant
    {
        /// <summary>
        /// ENABLE_ARC_GIS
        /// </summary>
        public const string ENABLE_ARC_GIS = "EnableArcGis";
        
        /// <summary>
        /// Scenario: when client app users choose one point which does belong to boundary of any one of existed agency on the Map.
        ///           system will return the agency configured by current key.
        /// </summary>
        public const string GENERIC_AGENCY_NAME = "GenericAgencyName";
        
        /// <summary>
        /// Administrator user name.
        /// </summary>
        public const string ADMINISTRATOR_USER_NAME = "AdminUserName";

        /// <summary>
        /// Administrator user password.
        /// </summary>
        public const string ADMINISTRATOR_USER_PASSWORD = "AdminUserPassword";

        /// <summary>
        /// Current sub system
        /// </summary>
        public const string CURRENT_SUB_SYSTEM = "current_sub_system";

        /// <summary>
        /// IsIsolateCacheServer
        /// </summary>
        public const string IS_ISOLATE_CACHESERVER = "IsIsolateCacheServer";
        
        /// <summary>
        /// Key in configuration file
        /// </summary>
        public const string SUB_SYSYEM_API_URL = "Ref_InternalAPI_API";
        public const string SUB_SYSYEM_ADMIN_URL = "Ref_InternalAPI_Admin";
        public const string SUB_SYSYEM_USER_URL = "Ref_InternalAPI_User";
        public const string SUB_SYSYEM_OAUTH_URL = "Ref_InternalAPI_OAuth";
        public const string SUB_SYSYEM_DEVELOPER_URL = "Ref_InternalAPI_Dev";
        public const string SUB_SYSTEM_ACCESS_KEY = "InternalAPI_AccessKey";

        public const string INTERNAL_API_TIMEOUT_PER_SECONDS = "InternalAPI_Timeout_Seconds";

        ///// <summary>
        ///// LogWhenMethodElapsedTimeExceed
        ///// </summary>
        //public const string LOG_WHEN_METHOD_ELAPSEDTIME_EXCEED = "LogWhenMethodElapsedTimeExceed";

        //#region Private Constants

        ///// <summary>
        ///// Configuration node name.
        ///// </summary>
        //private const string LOG_LEVEL = "LogLevel";
        //private const TraceEventType DEFAULT_LOG_LEVEL = TraceEventType.Information;

        //#endregion

        //#region Public Static Properties

        ///// <summary>
        ///// Gets LogLevel from configuration file.
        ///// </summary>
        //public static TraceEventType LogLevel
        //{
        //    get
        //    {
        //        string logLevel = AzureConfiguration.GetConfigurationSetting(LOG_LEVEL); 

        //        if (String.IsNullOrWhiteSpace(logLevel))
        //        {
        //            return DEFAULT_LOG_LEVEL;
        //        }
        //        else
        //        {
        //            TraceEventType result;
        //            bool isParsedSuccess = Enum.TryParse<TraceEventType>(logLevel, out result);

        //            if (isParsedSuccess)
        //            {
        //                return result;
        //            }
        //            else
        //            {
        //                return DEFAULT_LOG_LEVEL;
        //            }
        //        }
        //    }
        //}

        //#endregion Public Static Properties
    }
}
