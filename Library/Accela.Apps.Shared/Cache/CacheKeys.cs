using Accela.Apps.Shared.Toolkits.Encrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Accela.Apps.Shared.Cache
{
    public static class CacheKeys
    {
        public const string HOSTS = "hosts";
        public const string AGENCIES = "agencies";
        public const string APPS = "apps";
        public const string RESOURCES = "resources";
        public const string SCOPES = "scopes";
        public const string ENVIRONMENTS = "environments";

        public const string ENVIRONMENTS_BY_AGENCYNAME = "environments_agencyname_";
        public const string APP_BY_APPID = "app_appid_";
        public const string ACCOUNT_BY_ID = "account_id_";
        public const string AGENCY_BY_NAME = "agency_name_";
        public const string AGENCY_SETTINGS_BY_AGENCY_NAME = "agency_settings_";
        public const string AGENCY_APPS_BY_AGENCY_NAME = "agency_apps_"; // only cache AgencyApps table data, not all apps for this agency.
        public const string BIZ_AGENCY_TOKEN_BY_AGENCY_ENV_CLOUDUSER = "biz_agency_token_agency_env_clouduser_";
        public const string BIZ_CITIZEN_TOKEN_BY_AGENCY_ENV_CLOUDUSER = "biz_citizen_token_agency_env_clouduser_";
        public const string BIZ_ANONYMOUS_TOKEN_BY_AGENCY_ENV_CLOUDUSER = "biz_anonymous_token_agency_env_clouduser_";

        public static string ToStringWithComma(this List<string> values)
        {
            if(values == null || values.Count == 0)
            {
                return String.Empty;
            }
            string result = "";
            values.ForEach(k => result += "," + k);

            if (result.Length > 0) result = result.Remove(0, 1);

            return result;
        }

        public static string ToStringWithComma(this string[] values)
        {
            if (values == null || values.Length == 0)
            {
                return String.Empty;
            }
            string result = "";

            foreach(var v in values)
            {
                result += "," + v;
            }

            if (result.Length > 0) result = result.Remove(0, 1);

            return result;
        }

        public static string BuildCacheKey(params string[] keyParts)
        {
            if (keyParts == null || keyParts.Length == 0)
            {
                return String.Empty;
            }

            var updatedKeyParts = keyParts.Select(p => HttpUtility.UrlEncode((p ?? String.Empty).Trim().ToUpperInvariant())).ToArray();
            var tempResult = String.Join("&", updatedKeyParts);
            var result = MD5Helper.GetMd5Hash(tempResult).ToLowerInvariant();
            return result;
        }
    }
}
