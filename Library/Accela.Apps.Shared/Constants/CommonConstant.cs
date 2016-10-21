using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Apps.Shared.Contants
{
    public enum AppType
    {
        Agency = 0,
        Citizen = 1,
        Unknown = 999
    }

    public enum AccountType
    {
        AA = 0,
        Email,
        Facebook = 20,
        Twitter,
        GooglePlus,
        WindowsLive,
        Yahoo,
        ACA,
        Unknown = 999,
    }

    /// <summary>
    /// used for authentication.
    /// </summary>
    public enum CredentialType
    {
        Unknown = 0,
        Password,
        Certificate,
        Ticket,
        SAML2
    }

    public enum TokenType
    {
        Anonymous = 0,
        CivicUser = 1,
        AgencyUser = 2
    }

    /// <summary>
    /// The admin Role Type
    /// </summary>
    public enum AdminRoleType
    {
        CloudAdmin = 1,
        HostAdmin = 2,
        AgencyAdmin = 3
    }

    /// <summary>
    /// same definitions with type in Microsoft.WindowsAzure.StorageClient.BlobContainerPublicAccessType
    /// </summary>
    public enum BlobPublicAccessType
    {
        Blob,
        Container,
        Off
    }

    public enum Environments
    {
        PROD,
        TEST,
        DEV,
        STAGE,
        CONFIG,
        SUPP
    }

    public enum AccelaServerType
    {
        BizServer = 0,
        WebServer = 1,
        Unknown = 999
    }

    public enum BizServerType
    {
        AA = 0,
        GeoTMS = 1,
        Unknown = 999,
    }

    public enum APIAuthenticationType
    {
        /// <summary>
        /// None authentication required. -- e.g: get access token api
        /// </summary>
        NONE = 0,

        /// <summary>
        /// User Identity - CivicId login reqired
        /// </summary>
        USER_IDENTITY = 1,

        /// <summary>
        /// App Identity - AppId & AppSecret  -- e.g: app data and app setting apis
        /// </summary>
        APP_IDENTITY = 2,

        /// <summary>
        /// Internal Access key required for internal api.
        /// </summary>
        ACCESS_KEY = 3,

        /// <summary>
        /// User Identity with linked ACA Anonymous Account - access token with aca anonymous
        /// </summary>
        USER_IDENTITY_WITH_ACA_ANONYMOUS = 4,

        /// <summary>
        /// User Identity with linked Automation Account - access token with linked ACA registered account/access token with Linked AA account
        /// </summary>
        USER_IDENTITY_WITH_LINKED_AUTOMATION_ACCOUNT = 5,
    }

    public enum ApiTypes
    {
        /// <summary>
        /// V4+ API
        /// </summary>
        NormalApi,

        /// <summary>
        /// GovXml API
        /// </summary>
        GovXml,

        /// <summary>
        /// V1 APIs in azure, or APIs with 'rest' prefix in biz server.
        /// </summary>
        LiteServiceWithRestPrefix,

        /// <summary>
        /// V3 API in azure, or APIs with 'v1' prefix in biz server.
        /// </summary>
        V1RestApi,

        /// <summary>
        /// gateway API
        /// </summary>
        GatewayApi,

        /// <summary>
        /// secure biz server APIs
        /// </summary>
        SecuredApi,

        /// <summary>
        /// other type of API
        /// </summary>
        Others
    }

    public static class Constant
    {
        public const string STAT_PERIOD_UNTIL_NOW = "0";

        public static Guid CIVIC_ID_ANONYMOUS_GUID = Guid.Empty;
        public const string ACA_ANONYMOUS = "anonymous";
        public const int ACA_ANONYMOUS_PRIORITY = 999;
        public static DateTime NEVER_EXPIRED = new DateTime(9999, 12, 30);
        public const string PUBLIC_USER_GROUP_ID = "00000000-0000-0000-0000-000000000001";
        public const string AGENCY_USER_GROUP_ID = "00000000-0000-0000-0000-000000000002";

        public const string COMMON_Y = "Y";
        public const string COMMON_N = "N";
        public const string COMMON_YES = "YES";
        public const string COMMON_NO = "NO";
    }

    /// <summary>
    /// Stat Name constant.
    /// </summary>
    public static class StatNames
    {
        public const string NewUsersCountPerDay         = "NewUsersCountPerDay";
        public const string NewDevelopersCountPerDay    = "NewDevelopersCountPerDay";
        public const string NewAppsCountPerDay          = "NewAppsCountPerDay";
        public const string NewAgenciesCountPerDay      = "NewAgenciesCountPerDay";
        public const string NewTransactionsCountPerDay  = "NewTransactionsCountPerDay";

        public const string TotalUsers                  = "TotalUsers";
        public const string TotalDevelopers             = "TotalDevelopers";
        public const string TotalApps                   = "TotalApps";
        public const string TotalAgencies               = "TotalAgencies";
        public const string TotalTransactions           = "TotalTransactions";
		
        public const string GroupTransactionsByApps     = "GroupTransactionsByApps";
        public const string GroupTransactionsByAgencies = "GroupTransactionsByAgencies";
        public const string GroupTransactionsByAppsVsAgencies = "GroupTransactionsByAppsVsAgencies";

        public const string UserGrowthPerQuarter        = "UserGrowthPerQuarter";
        public const string DeveloperGrowthPerQuarter   = "DeveloperGrowthPerQuarter";
        public const string AppsGrowthPerQuarter        = "AppsGrowthPerQuarter";
        public const string AgenciesGrowthPerQuarter    = "AgenciesGrowthPerQuarter";
    }

}
