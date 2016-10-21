using System;
using System.Collections.Generic;
using Accela.Apps.GeoServices.Response;
using Accela.Apps.Shared.Toolkits.Encrypt;
using System.Runtime.Caching;

namespace Accela.Apps.GeoServices.Geocode.HelpersForArcGisV1011
{
    public static class TokenCacheV1011Helper
    {
        private const string CACHE_PREFIX = "AccelaArcGisTokenCache";

        public static string BuildTokenCacheKey(params string[] cacheKeySources)
        {
            if (cacheKeySources == null || cacheKeySources.Length == 0)
            {
                throw new ArgumentException("Invalid token cache key.");
            }

            var cacheKeySourcesString = String.Join("_", cacheKeySources).ToLower();
            var result = CACHE_PREFIX + MD5Helper.GetMd5Hash(cacheKeySourcesString);
            return result;
        }

        public static TokenResponse GetTokenModelFromCache(string tokenCacheKey)
        {
            var defaultMemoryCache = MemoryCache.Default;

            var result = defaultMemoryCache.Contains(tokenCacheKey) ? defaultMemoryCache[tokenCacheKey] as TokenResponse : null;
            return result;
        }

        public static void SaveTokenModelToCache(string tokenCacheKey, TokenResponse tokenModel)
        {
            if (String.IsNullOrWhiteSpace(tokenCacheKey))
            {
                throw new ArgumentException("Invalid token cache key.");
            }

            var defaultMemoryCache = MemoryCache.Default;

            if (defaultMemoryCache.Contains(tokenCacheKey))
            {
                defaultMemoryCache.Remove(tokenCacheKey);
            }

            if (tokenModel != null)
            {
                var cachePolicy = new CacheItemPolicy();

                //restrict cache expiration to under 1 day.
                var maxAbsoluteExpiration = DateTime.Now.AddDays(1);
                var absoluteExpiration = tokenModel.ExpireTime > maxAbsoluteExpiration ? maxAbsoluteExpiration : tokenModel.ExpireTime;

                cachePolicy.AbsoluteExpiration = absoluteExpiration;
                defaultMemoryCache.Add(tokenCacheKey, tokenModel, cachePolicy);
            }
        }

        public static void ClearCache()
        {
            var defaultMemoryCache = MemoryCache.Default;
            defaultMemoryCache.Trim(100);
        }
    }
}
