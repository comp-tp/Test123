using System;
using System.Collections.Generic;

namespace Accela.Core.Logging.Util
{
    public static class SensitiveDataFilter
    {
        static SensitiveDataFilter()
        {
            init();
        }

        private static HashSet<FilterConfig> CONFIG = null;
        private const string MASK_STAR = "***";
        public static void init()
        {
            /*
            1.password
                password=admin& | &password=admin | &password=admin&
                {"agency":"QA","userId":"admin","password":"admin"}

            2.client_secret

            3.appSeret

            4.token
            {"access_token":"P24cHcN...","refresh_token":"U3lI..."}
            v4/records?token=23232323232323....&type=xx
            v4/records?type=xx&token=23232323232323....&a=c
            v4/records?a=c&token=23232323232323....
            7.applicationstate
            <ApplicationState>39617989752001985270</ApplicationState>
            
            "driverLicenseNumber":"18850115"
            "socialSecurityNumber":"111222333"
            */
            CONFIG = new HashSet<FilterConfig>();
            CONFIG.Add(new FilterConfig("password", 8, 1));
            CONFIG.Add(new FilterConfig("creditcard", "\"", 3));
            CONFIG.Add(new FilterConfig("socialSecurityNumber", "\"", 3));   // SSN
            CONFIG.Add(new FilterConfig("client_secret", 32, 1));   // Auth client_secret could be request body
            CONFIG.Add(new FilterConfig("appSecret", 8, 3));    // TODO: developer portal should prevent logging appSecret
            CONFIG.Add(new FilterConfig("token", 32, 3));
            CONFIG.Add(new FilterConfig("driverLicenseNumber", "\"", 3));
            CONFIG.Add(new FilterConfig("<ApplicationState>", "</ApplicationState>"));
        }

        public static string Filter(string content)
        {
            try
            {

                foreach (var config in CONFIG)
                {
                    if (string.IsNullOrEmpty(config.endMarkString))
                    {
                        content = MaskString(content, config.Key, config.maskStringCount, config.skipMaskCharLength);
                    }
                    else
                    {
                        content = MaskString(content, config.Key, config.skipMaskCharLength, config.endMarkString);
                    }
                }

                return content;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError(ex.ToString());
            }

            return content;
        }

        public static string MaskString(string content, string key, int maskStringCount = 6, int skipMaskCharLength = 1)
        {
            try
            {

                if (string.IsNullOrEmpty(content) || string.IsNullOrEmpty(key) || maskStringCount < 1)
                {
                    return content;
                }

                var index = content.IndexOf(key, StringComparison.OrdinalIgnoreCase);
                while (index > -1)
                {
                    int length = content.Length;
                    int startIndex = index + key.Length + skipMaskCharLength;

                    if(startIndex >= length - 1)
                    {
                        break;
                    }

                    int removeCount = (startIndex + maskStringCount) <= length ? maskStringCount : length - startIndex;
                    content = content.Remove(startIndex, removeCount);
                    content = content.Insert(startIndex, MASK_STAR);

                    index = content.IndexOf(key, startIndex, StringComparison.OrdinalIgnoreCase);
                }
                return content;
            }
            catch(Exception ex)
            {
                return content;
            }
        }

        public static string MaskString(string content, string key, int skipMaskCharLength, string endMarkString)
        {
            try
            {

                if (string.IsNullOrEmpty(content) || string.IsNullOrEmpty(key) || string.IsNullOrEmpty(endMarkString))
                {
                    return content;
                }

                var index = content.IndexOf(key, StringComparison.OrdinalIgnoreCase);
                while (index > -1)
                {
                    int length = content.Length;
                    int startIndex = index + key.Length + skipMaskCharLength;

                    if (startIndex >= length - 1)
                    {
                        break;
                    }
                    // find endMark string position
                    int endIndex = content.IndexOf(endMarkString, startIndex, StringComparison.OrdinalIgnoreCase);

                    if(endIndex == -1)
                    {
                        content = content.Substring(0, startIndex) + MASK_STAR;
                        break;
                    }

                    content = content.Remove(startIndex, endIndex - startIndex);
                    content = content.Insert(startIndex, MASK_STAR);

                    index = content.IndexOf(key, startIndex + MASK_STAR.Length + endMarkString.Length, StringComparison.OrdinalIgnoreCase);
                }
                return content;
            }
            catch (Exception ex)
            {
                return content;
            }
        }

        class FilterConfig
        {
            public string Key;
            public int maskStringCount;
            public int skipMaskCharLength;
            public string endMarkString;
            public FilterConfig(string Key, int maskStringCount, int skipMaskCharLength)
            {
                this.Key = Key;
                this.maskStringCount = maskStringCount;
                this.skipMaskCharLength = skipMaskCharLength;
            }

            public FilterConfig(string Key, string endMarkString, int skipMaskCharLength = 0)
            {
                this.Key = Key;
                this.endMarkString = endMarkString;
                this.skipMaskCharLength = skipMaskCharLength;
            }
        }
    }

}
