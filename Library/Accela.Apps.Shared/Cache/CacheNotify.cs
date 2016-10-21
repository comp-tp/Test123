using Accela.Apps.Shared.Contants;
using Accela.Apps.Shared.RestClients;
using Accela.Apps.Shared.WSModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using RestSharp;
using Accela.Core.Logging;

using Accela.Core.Ioc;
using Accela.Core.Configurations;
using Accela.Infrastructure.Configurations;

namespace Accela.Apps.Shared.Cache
{

    public static class CacheNotify
    {

        //private readonly static Func<IConfiguration> ConfigurationSettingsProvider;
        private static IConfigurationReader ConfigurationSettings { get { return ConfigurationSettingsManager.Get(); } }

        static CacheNotify()
        {
            //ConfigurationSettingsProvider = ConfigurationProvider.Instance.Get; //IocContainer.Resolve<IConfiguration>();
        }


        /// <summary>
        /// Get an ILog instance.
        /// </summary>
        private static ILog Log
        {
            get
            {
                return LogFactory.GetLog();
            }
        }

        public static void SendNotify(IDictionary<string, IList<string>> cacheKeys2subSystems)
        {
            if (cacheKeys2subSystems == null || cacheKeys2subSystems.Count == 0)
            {
                Log.Error("cacheKeys2subSystems is required.", "CacheNotify.SendNotify()", "SendNotify");
                return;
            }

            //bool isIsolateCacheServer = false;

            //Boolean.TryParse(AzureConfiguration.GetConfigurationSetting(ConfigurationConstant.IS_ISOLATE_CACHESERVER),out isIsolateCacheServer);
            //if (isIsolateCacheServer)
            //{

            //}

            // group cache key by subsystem
            Dictionary<string, List<string>> subsystemToCacheKeys = new Dictionary<string, List<string>>();

            foreach (var item in cacheKeys2subSystems)
            {
                var notifySubsystems = item.Value as IList<string>;
                if(notifySubsystems != null)
                {
                    foreach (var url in notifySubsystems)
                    {
                        if(subsystemToCacheKeys.ContainsKey(url))
                        {
                            (subsystemToCacheKeys[url] as List<string>).Add(item.Key);
                        }
                        else
                        {
                            subsystemToCacheKeys.Add(url, new List<string> { item.Key });
                        }
                    }
                }
            }


            foreach (var item in subsystemToCacheKeys)
            {
                var cache_keys = item.Value as List<string>;
                if(cache_keys == null || cache_keys.Count == 0)
                {
                    continue;
                }

                string cache_keys_string = cache_keys.ToStringWithComma();

                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        InternalAPIClient client = new InternalAPIClient();
                        string subSystemUrl = ConfigurationSettings.Get(item.Key);

                        if (String.IsNullOrWhiteSpace(subSystemUrl))
                        {
                            Log.Critical("No Configuration data for " + item.Key, null, "SendNotify");
                            return;
                        }

                        string subSystemCacheUrl = subSystemCacheUrl = String.Concat(subSystemUrl, "/caches/remove"); 

                        WSClearCacheRequest request = new WSClearCacheRequest();
                        request.CacheKeys = cache_keys.ToArray();

                        var response = client.Execute<GenericResultResponse<string>>(subSystemCacheUrl, request, Method.PUT);

                        if (response != null && !String.IsNullOrWhiteSpace(response.Result))
                        {
                            // response is ok
                            string detail = string.Format("request url: {0}, response: {1}", subSystemCacheUrl, response.Result);
                            Log.Info("Cache refresh successfully, cache key is " + cache_keys_string, detail, "SendNotify");
                        }
                        else
                        {
                            string responseString = response == null ? "response is null" : response.Result;
                            string detail = string.Format("request url: {0}, response: {1}", subSystemCacheUrl, responseString);
                            Log.Error("Cache refresh failed, cache key is " + cache_keys_string, detail, "SendNotify");
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Critical(ex, "SendNotify");
                    }
                });
            }
        }

		/// <summary>
		/// Send Notification to other subsystems
		/// </summary>
		/// <param name="cacheKey">cacheKey</param>
        /// <param name="subSystemURLSettings">
        /// one or more below values:
        /// Accela.Apps.Shared.Contants.ConfigurationConstant.SUB_SYSYEM_API_URL
        /// Accela.Apps.Shared.Contants.ConfigurationConstant.SUB_SYSYEM_ADMIN_URL
        /// Accela.Apps.Shared.Contants.ConfigurationConstant.SUB_SYSYEM_USER_URL
        /// Accela.Apps.Shared.Contants.ConfigurationConstant.SUB_SYSYEM_OAUTH_URL
        /// Accela.Apps.Shared.Contants.ConfigurationConstant.SUB_SYSYEM_DEVELOPER_URL
		/// </param>	
        public static void SendNotify(string cacheKey, IList<string> subSystemURLSettingKeys)
        {

            if(String.IsNullOrWhiteSpace(cacheKey))
            {
                Log.Error("cacheKey is required.", "CacheNotify.SendNotify()", "SendNotify");
                return;
            }

            IDictionary<string, IList<string>> cacheKeys = new Dictionary<string, IList<string>>();
            cacheKeys.Add(cacheKey, subSystemURLSettingKeys);
            SendNotify(cacheKeys);
        }
    }
}
